using System.ComponentModel.DataAnnotations;

namespace ProductBox_ExerciseSolution.Models
{
    public class Customer
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int CustomerTypeId { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string Zip { get; set; }
        
        [StringLength(50)]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        
        public CustomerType? CustomerType { get; set; }
        
                
        //public static implicit operator int(Customer v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
