using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidPerson
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (value.Any(s => char.IsDigit(s) || char.IsSymbol(s)))
                {
                    throw new InvalidPersonNameException("Name cannot contain numeric or special symbols.");
                }

                this.name = value;
            }
        }

        public string Email { get; private set; }
    }
}
