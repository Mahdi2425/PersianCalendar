using System;

namespace PersianCalendar.Models
{
    /// <summary>
    /// Base class for all domain entities.
    /// Provides common auditing and soft-delete fields.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>Unique identifier for the entity.</summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>When the entity was created (UTC).</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>When the entity was last updated (UTC).</summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Soft-delete flag. True means the entity is logically deleted.</summary>
        public bool IsDeleted { get; set; }

        /// <summary>Whether the entity is active/enabled.</summary>
        public bool IsActive { get; set; } = true;

        /// <summary>When the entity was soft-deleted (UTC).</summary>
        public DateTime? DeletedAt { get; set; }
    }
}