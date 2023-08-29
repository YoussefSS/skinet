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
    }
}