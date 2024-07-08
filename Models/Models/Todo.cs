using System;
namespace Console_core.Models.Models
{
    public class Todo
    {
        private readonly int _id;
        private string _description;
        private bool _done;
        private Person _assignee;

        public Todo(int id, string description)
        {
            _id = id;
            Description = description;
            _done = false;
            _assignee = null;
        }

        public int Id
        {
            get { return _id; }
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
