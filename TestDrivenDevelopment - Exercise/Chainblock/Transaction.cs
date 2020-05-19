using System;

using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id 
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.id = value;
            } 
        }

        public TransactionStatus Status { get; set; }

        public string From 
        {
            get
            {
                return this.from;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.from = value;
            }
        }

        public string To 
        {
            get
            {
                return this.to;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.to = value;
            }
        }

        public double Amount 
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            if (this.Amount == other.Amount)
            {
                return 0;
            }
            else if (this.Amount > other.Amount)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
