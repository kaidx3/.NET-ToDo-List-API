namespace ezToDo.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskCount { get; set; }
        public int AccountId { get; set; }

        public List() { }
    }
}
