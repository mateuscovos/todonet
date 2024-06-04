namespace ToDo.Domain.Entities
{
    public class TaskDomain : Base
    {
        public static TaskDomain New(string name, string description, DateTime expireAt)
        {
            var task = new TaskDomain
            {
                Name = name,
                Description = description,
                IsDone = false,
                ExpireAt = expireAt,
            };

            task.IsValid();

            return task;
        }

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public bool IsDone { get; private set; }
        public DateTime ExpireAt { get; private set; }

        public void ChangeName(string value)
        {
            if (IsDisableToChange()) return;

            Name = value;
            ChangeUpdateDate();
        }

        public void ChangeDescription(string value)
        {
            if (IsDisableToChange()) return;

            Description = value;
            ChangeUpdateDate();
        }

        public void Finish()
        {
            if (IsDisableToChange()) return;

            IsDone = true;
            ChangeUpdateDate();
        }

        public bool IsExpired() => ExpireAt.Date <= DateTime.UtcNow.Date;

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name) || Name.Length < 4) throw new ArgumentException("Name is invalid");
            if (string.IsNullOrEmpty(Description) || Description.Length < 4) throw new ArgumentException("Description is invalid");
            if (ExpireAt.Date < DateTime.UtcNow.Date) throw new ArgumentException("Expire At is invalid"); ;

            return true;
        }

        private bool IsDisableToChange() => !(IsDone || IsActive);
    }
}
