using System;
using System.ComponentModel.DataAnnotations;

namespace Income.Models
{
    public class Finance: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual User User { get; set; }
    }
}
