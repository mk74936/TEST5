namespace TEST5.API.Models.Domain
{
    public class Order
    {
        public Guid ID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }

        //Navigation Properties

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
