using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Income.Models
{
    public class User: BaseEntity
    {
        public User()
        {
            Finances = new List<Finance>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        public virtual List<Finance> Finances { get; set; }
    }
}
