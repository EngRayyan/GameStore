using System.ComponentModel.DataAnnotations;

namespace Product.Dots
{
    public class InsertGameDot
    {
        [Required]
        public long QRcode { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Game name must be between 2 and 50 characters")]
        public string gameName { get; set; }
        public string? place { get; set; }
        [Required]
        public bool IsUsed { get; set; } = true;
        [Required]
        [Range(0,200,ErrorMessage = "Price must be between 0 and 200")]
        public decimal price { get; set; }
      
}
}
