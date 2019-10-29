using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private readonly Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.repo = new Dictionary<string, Student>();
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            switch (args[0])
            {
                case "Create":
                    var name = args[1];
                    var age = int.Parse(args[2]);
                    var grade = double.Parse(args[3]);
                    if (!this.repo.ContainsKey(name))
                    {
                        var student = new Student(name, age, grade);
                        this.repo[name] = student;
                    }

                    break;
                case "Show":
                    name = args[1];
                    if (this.repo.ContainsKey(name))
                    {
                        var student = this.repo[name];
                        string view = $"{student.Name} is {student.Age} years old.";

                        if (student.Grade >= 5.00)
                        {
                            view += " Excellent student.";
                        }
                        else if (student.Grade < 5.00 && student.Grade >= 3.50)
                        {
                            view += " Average student.";
                        }
                        else
                        {
                            view += " Very nice person.";
                        }

                        Console.WriteLine(view);
                    }

                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
