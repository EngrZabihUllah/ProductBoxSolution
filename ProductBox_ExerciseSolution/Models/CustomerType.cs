using System.ComponentModel.DataAnnotations;

namespace ProductBox_ExerciseSolution.Models
{
    public class CustomerType
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
