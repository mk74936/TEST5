namespace TEST5.API.Models.DTO
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long MobileNumber { get; set; }
        public string Product_Name { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
