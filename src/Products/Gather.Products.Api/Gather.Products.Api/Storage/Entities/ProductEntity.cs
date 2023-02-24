using System.ComponentModel.DataAnnotations;

namespace Gather.Products.Api.Storage.Entities
{
    public class ProductEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [MaxLength(1200)]
        public string Description { get; set; }

        public string Notes { get; set; }

        [Required]
        public string Category { get; set; }


        public decimal Weight { get; set; }
        public string WeightUnit { get; set; }

        public string BarCode { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
