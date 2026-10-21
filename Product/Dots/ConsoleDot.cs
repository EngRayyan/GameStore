namespace Product.Dots
{
    public class ConsoleDot
    {
        public long QRcode { get; set; }
        public string consoleName { get; set; }
        public string? place { get; set; }
        public bool IsUsed { get; set; }
        public decimal price { get; set; }
        public int edition { get; set; }
        public bool isLimitedEdition { get; set; }
        public bool isRepaired { get; set; }
    }
}
