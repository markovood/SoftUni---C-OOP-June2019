using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private HashSet<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException();
            }

            if (this.transactions.Any(tr => tr.Id == tx.Id))
            {
                throw new InvalidOperationException("Cannot add transaction with already existing ID!");
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!this.Contains(id))
            {
                throw new ArgumentException();
            }

            this.transactions.First(tr => tr.Id == id).Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException();
            }

            return this.transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.transactions.Any(tr => tr.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions.Where(tr => tr.Amount >= lo && tr.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var found = this.transactions
                .Where(tr => tr.Status == status)
                .OrderByDescending(tr => tr.Amount)
                .Select(tr => tr.To);

            if (found.Count() == 0)
            {
                throw new InvalidOperationException("No such transaction status!");
            }
            else
            {
                return found;
            }
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var found = this.transactions
                .Where(tr => tr.Status == status)
                .OrderByDescending(tr => tr.Amount)
                .Select(tr => tr.From);

            if (found.Count() == 0)
            {
                throw new InvalidOperationException("No such transaction status!");
            }
            else
            {
                return found;
            }
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            return this.transactions.First(tr => tr.Id == id);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!this.transactions.Any(tr => tr.To == receiver))
            {
                throw new InvalidOperationException("No such receiver found!");
            }

            var allTransactionsFromReceiver = this.transactions.Where(tr => tr.To == receiver);
            if (allTransactionsFromReceiver.All(tr => tr.Amount < lo))
            {
                throw new InvalidOperationException("No such transaction with this lower bound found!");
            }
            
            if (allTransactionsFromReceiver.All(tr => tr.Amount > hi))
            {
                throw new InvalidOperationException("No such transaction with this upper bound found!");
            }

            return allTransactionsFromReceiver
                .Where(tr => tr.Amount >= lo && tr.Amount < hi)
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var found = this.transactions
                .Where(tr => tr.To == receiver)
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);

            if (found.Count() == 0)
            {
                throw new InvalidOperationException("No such receiver found!");
            }

            return found;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var found = this.transactions
                .Where(tr => tr.From == sender)
                .Where(tr => tr.Amount > amount)
                .OrderByDescending(tr => tr.Amount);

            if (found.Count() == 0)
            {
                throw new InvalidOperationException("No such sender found!");
            }

            return found;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var found = this.transactions
                .Where(tr => tr.From == sender)
                .OrderByDescending(tr => tr.Amount);

            if (found.Count() == 0)
            {
                throw new InvalidOperationException("No such sender exists!");
            }

            return found;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> found = this.transactions
                                                    .Where(tr => tr.Status == status)
                                                    .OrderByDescending(tr => tr.Amount);
            if (found.Count() == 0)
            {
                throw new InvalidOperationException("No transactions with given status!");
            }
            else
            {
                return found;
            }
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions
                .Where(tr => tr.Status == status)
                .Where(tr => tr.Amount <= amount)
                .OrderByDescending(tr => tr.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.transactions.GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            var transactionToRemove = this.transactions.First(tr => tr.Id == id);
            this.transactions.Remove(transactionToRemove);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
