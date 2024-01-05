namespace TodoList.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Task { get; set; } = "";
        public bool IsDone { get; set; }
    }
}
