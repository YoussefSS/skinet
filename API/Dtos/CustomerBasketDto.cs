using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
        public int? DeliveryMethodId { get; set; } // Optional as the user can only select the delivery method during checkout
        public string ClientSecret { get; set; } // Used by stripe to confirm payment intent
        public string PaymentIntentId { get; set; } // We'll use this to update the payment intent if the client updates any info
        public decimal ShippingPrice { get; set; }
    }
}