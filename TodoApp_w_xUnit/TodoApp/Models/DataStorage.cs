namespace TodoApp.Models
{
    public class DataStorage
    {
        public List<Todo> Todos { get; set; }
        private int nextId = 0;

        public DataStorage()
        {
            Todos = new List<Todo>();
        }
        
        public int SetNextId()
        {
            nextId++;
            return nextId;
        }
    }
}
