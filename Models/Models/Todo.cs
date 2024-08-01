using System;
using System.ComponentModel.DataAnnotations;
namespace Console_core.Models.Models
{
    public class Todo
    {
        [Key]
        public int _id { get; private set; }
        public string _description { get; private set; }
        public bool _done { get; private set; }
        public Person _assignee { get; private set; }
        public Todo() { }
        public Todo(int id, string description)
        {
            _id = id;
            Description = description;
            _done = false;
            _assignee = null;
        }

        public int Id
        {
            get { return _Id; }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description cannot be null or empty.");
                }
                _description = value;
            }
        }

        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }

        public Person Assignee
        {
            get { return _assignee; }
            set { _assignee = value; }
        }
    }
}
