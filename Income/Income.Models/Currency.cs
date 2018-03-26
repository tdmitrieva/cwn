using System.ComponentModel.DataAnnotations;

namespace Income.Models
{
    public class Currency: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Symbol { get; set; }
    }
}
