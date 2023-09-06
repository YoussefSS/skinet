namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; } // customer/angular will generate the ID
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; } // Optional as the user can only select the delivery method during checkout
        public string ClientSecret { get; set; } // Used by stripe to confirm payment intent
        public string PaymentIntentId { get; set; } // We'll use this to update the payment intent if the client updates any info
        public decimal ShippingPrice { get; set; }
    }
}