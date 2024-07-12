using Console_core.Models.Models;

namespace Console_core.Date
{
    public class TodoService
    {
        private static Todo[] todoItems = new Todo[0];

        public int Size()
        {
            return todoItems.Length;
        }

        public Todo[] FindAll()
        {
            return todoItems;
        }

        public Todo FindById(int todoId)
        {
            return todoItems.FirstOrDefault(todo => todo.Id == todoId);
        }

        public Todo CreateTodoItem(string description, bool done, Person assignee)
        {
            Todo newTodo = new Todo(TodoSequencer.NextTodoId(), description)
            {
                Done = done,
                Assignee = assignee
            };
            Array.Resize(ref todoItems, todoItems.Length + 1);
            todoItems[^1] = newTodo;
            return newTodo;
        }

        public void Clear()
        {
            todoItems = new Todo[0];
        }
    }
}
