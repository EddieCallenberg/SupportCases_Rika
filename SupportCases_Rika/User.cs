using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupportCases_Rika
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Id { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool IsRegistered { get; set; } = false;

        [Required]
        public bool IsVerified { get; set; } = false;

        // Navigation properties
        public ICollection<SupportCase> CustomerCases { get; set; }
        public ICollection<SupportCase> OwnedCases { get; set; }
    }
}