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

        public void UpdateTodoItem(Todo updatedTodo)
        {
            var existingTodo = todoItems.FirstOrDefault(todo => todo.Id == updatedTodo.Id);
            if (existingTodo != null)
            {
                existingTodo.Description = updatedTodo.Description;
                existingTodo.Done = updatedTodo.Done;
                existingTodo.Assignee = updatedTodo.Assignee;
            }
        }

        public void Clear()
        {
            todoItems = new Todo[0];
        }

        public void RemoveTodoItem(int todoId)
        {
            int index = Array.FindIndex(todoItems, todo => todo.Id == todoId);
            if (index != -1)
            {
                todoItems = todoItems.Where((source, i) => i != index).ToArray();
            }
        }
  
    // Add New methods point 10 
    public Todo[] FindByDoneStatus(bool doneStatus)
    {
    return todoItems.Where(todo => todo.Done == doneStatus).ToArray();
    }
    public Todo[] FindByAssignee(int personId)
    {
    return todoItems.Where(todo => todo.Assignee != null && todo.Assignee.Id == personId).ToArray();
     }
    public Todo[] FindByAssignee(Person assignee)
    {
    return todoItems.Where(todo => todo.Assignee == assignee).ToArray();
    }
    public Todo[] FindUnassignedTodoItems()
    {
    return todoItems.Where(todo => todo.Assignee == null).ToArray();
    }
    }
}
