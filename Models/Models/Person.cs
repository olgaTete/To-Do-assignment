using System;
using System.ComponentModel.DataAnnotations;
namespace Console_core.Models.Models
{
        public class Person
        {
        [Key]
        public int _id { get; private set;}
        public string _firstName { get; private set;}
        public string _lastName { get; private set;}

        public Person() { }

        public Person(int id, string firstName, string lastName)
            {
                _id = id;
                FirstName = firstName;
                LastName = lastName;
            }

            public int Id
            {
                get { return _id; }
            }

            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("First name cannot be null or empty.");
                    }
                    _firstName = value;
                }
            }

            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("Last name cannot be null or empty.");
                    }
                    _lastName = value;
                }
            }
        }
}
