using System.ComponentModel.DataAnnotations;

namespace RoleBasedProductMgmt.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
