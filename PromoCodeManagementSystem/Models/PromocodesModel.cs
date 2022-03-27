using System;
namespace PromoCodeManagementSystem.Models
{
    public class PromocodesModel
    {
        public string id { get; set; }
        public string promocode { get; set; }
        public string phoneNo { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime? updatedDateTime { get; set; }
    }
}
