using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportCases_Rika.Data
{
    internal class Enteties
    {
        namespace SupportCaseManagement.Enums
    {
        public enum CaseStatusType
        {
            NotOpened,
            Opened,
            Closed,
            Reopened
        }

        public enum CommunicationUsed
        {
            Chat,
            Mail,
            Voice_Video
        }

        public enum Categories
        {
            Order,
            Account,
            Product
        }
    }

    namespace SupportCaseManagement.Models
    {
        using SupportCaseManagement.Enums;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.ComponentModel.DataAnnotations;

        [Table("Users")]
        public class User : UserEntity
        {
        }

        [Table("CaseCategories")]
        public class CaseCategory
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [Required]
            public Categories CategoryName { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? UpdatedAt { get; set; }

            // Navigation properties
            public ICollection<SupportCase> SupportCases { get; set; }
            public ICollection<CaseSubCategory> SubCategories { get; set; }
        }

        [Table("CaseSubCategories")]
        public class CaseSubCategory
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [Required]
            public Guid ParentCategoryId { get; set; }

            [Required]
            [StringLength(50)]
            public string SubCategoryName { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? UpdatedAt { get; set; }

            // Navigation properties
            [ForeignKey(nameof(ParentCategoryId))]
            public CaseCategory ParentCategory { get; set; }
        }

        [Table("SupportCases")]
        public class SupportCase
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            public bool IsAssigned { get; set; } = false;

            public Guid? CustomerUserId { get; set; }

            [Required]
            public Guid CategoryId { get; set; }

            public Guid? CaseOwnerUserId { get; set; }

            public Guid? CaseCoOwnertUserId { get; set; }

            [Required]
            public Guid CaseStatusId { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? AssignedAt { get; set; }

            public DateTime? ClosedAt { get; set; }

            public DateTime? ReopenedAt { get; set; }

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

        [Table("CommunicationTypes")]
        public class CommunicationType
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [Required]
            public CommunicationUsed Name { get; set; }

            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? ClosedAt { get; set; }

            public DateTime? ReopenedAt { get; set; }

            // Navigation properties
            public ICollection<SupportCase> SupportCases { get; set; }
        }

        [Table("CaseStatus")]
        public class CaseStatus
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [Required]
            public CaseStatusType StatusName { get; set; }

            public DateTime? UpdatedAt { get; set; }

            // Navigation properties
            public ICollection<SupportCase> SupportCases { get; set; }
        }
    }
}
}
