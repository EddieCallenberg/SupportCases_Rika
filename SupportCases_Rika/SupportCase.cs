using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupportCases_Rika
{
    // SupportCases.cs
    [Table("SupportCases")]
    public class SupportCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool? IsAccepted { get; set; } = false;

        public Guid? CustomerUserId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Guid? CaseOwnerUserId { get; set; }

        public Guid? CaseCoOwnertUserId { get; set; }

        [Required]
        public Guid CaseStatusId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ClosedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ReopenedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid CommunicationTypeId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CustomerUserId))]
        public User CustomerUser { get; set; }

        [ForeignKey(nameof(CaseOwnerUserId))]
        public User CaseOwnerUser { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CaseCategory Category { get; set; }

        [ForeignKey(nameof(CaseStatusId))]
        public CaseStatus CaseStatus { get; set; }

        [ForeignKey(nameof(CommunicationTypeId))]
        public CommunicationType CommunicationType { get; set; }
    }
}