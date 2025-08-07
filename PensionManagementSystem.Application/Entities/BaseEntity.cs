namespace PensionManagementSystem.Application.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } // Nullable
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } // No default value
    }
}
