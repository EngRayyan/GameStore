using System.ComponentModel.DataAnnotations;

namespace Product.Dots
{
    public class GameDot
    {
        
        public long QRcode { get; set; }
        public string gameName { get; set; }
        public string place { get; set; }
        public decimal price { get; set; }
        public string IsUsed { get; set; }

    }
}
