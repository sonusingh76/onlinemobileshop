namespace MobileOnlineShopSystem.MobileMicroservice.Data_Access_Layer.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; } 
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

     
    }

}
