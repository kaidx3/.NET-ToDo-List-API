namespace ezToDo.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }

        public Task() { }
    }
}
