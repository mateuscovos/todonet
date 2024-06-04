namespace ToDo.Domain.Entities
{
    public class Base
    {
        public Base()
        {
            Id = "";
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public string Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        public void ChangeUpdateDate()
        {
            if (!IsActive)
                return;

            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate() => IsActive = false;
    }
}
