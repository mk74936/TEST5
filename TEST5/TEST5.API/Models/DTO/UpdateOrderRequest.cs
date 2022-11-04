namespace TEST5.API.Models.DTO
{
    public class UpdateOrderRequest
    {
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
    }
}
