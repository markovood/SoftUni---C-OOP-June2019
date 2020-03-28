using System;

namespace Telephony
{
    public class Smartphone : ITelephone, IBrowser
    {
        public void Call(string number)
        {
            if (IsValidNumber(number))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browse(string site)
        {
            if (IsValidURL(site))
            {
                Console.WriteLine($"Browsing: {site}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }

        private bool IsValidNumber(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidURL(string site)
        {
            foreach (var symbol in site)
            {
                if (char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
