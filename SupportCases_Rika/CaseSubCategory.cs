using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupportCases_Rika
{
    // CaseSubCategories.cs
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

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey(nameof(ParentCategoryId))]
        public CaseCategory ParentCategory { get; set; }
    }
}