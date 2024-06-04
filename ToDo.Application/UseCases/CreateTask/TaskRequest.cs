namespace ToDo.Application.UseCases.CreateTask
{
    public class TaskRequest
    {
        public TaskRequest(string name, string description, DateTime expireAt)
        {
            Name = name;
            Description = description;
            ExpireAt = expireAt;
        }

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime? ExpireAt { get; private set; }
    }
}
