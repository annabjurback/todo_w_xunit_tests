namespace TodoApp.Models
{
    public class DataStorage
    {
        public List<Todo> Todos { get; set; }

        public DataStorage()
        {
            Todos = new List<Todo>();
        }
    }
}
