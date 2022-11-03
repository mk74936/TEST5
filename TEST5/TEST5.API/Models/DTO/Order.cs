namespace TEST5.API.Models.DTO
{
    public class Order
    {
        public Guid ID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
    }
}
