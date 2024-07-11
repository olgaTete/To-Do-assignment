﻿using Console_core.Models.Models;

namespace Console_core.Date
{
    public class PeopleService
    {
        private static Person[] people = new Person[0];

        public int Size()
        {
            return people.Length;
        }

        public Person[] FindAll()
        {
            return people;
        }

        public Person FindById(int personId)
        {
            return people.FirstOrDefault(person => person.Id == personId);
        }

        public Person CreatePerson(string firstName, string lastName)
        {
            Person newPerson = new Person(PersonSequencer.NextPersonId(), firstName, lastName);
            Array.Resize(ref people, people.Length + 1);
            people[^1] = newPerson;
            return newPerson;
        }

        public void Clear()
        {
            people = new Person[0];
        }
    }
}
