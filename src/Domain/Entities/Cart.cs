using static CartService.Domain.Entities.CartItem;

namespace CartService.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Adăugăm o colecție de CartItem
        public ICollection<CartItem> Items { get; set; }  // Relația unu la mulți
    }
}
