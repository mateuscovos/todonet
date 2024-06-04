namespace ToDo.Domain.Entities
{
    public class Task : Base
    {
        public static Task New(string name, string description, DateTime expireAt)
        {
            return new Task
            {
                Name = name,
                Description = description,
                IsDone = false,
                ExpireAt = expireAt,
            };
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
            if (string.IsNullOrEmpty(Name) || Name.Length < 4) return false;
            if (string.IsNullOrEmpty(Description) || Description.Length < 4) return false;
            if (ExpireAt.Date < DateTime.UtcNow.Date) return false;

            return true;
        }

        private bool IsDisableToChange() => !(IsDone || IsActive);
    }
}
