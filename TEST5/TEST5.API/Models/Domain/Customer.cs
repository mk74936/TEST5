namespace TEST5.API.Models.Domain
{
    public class Customer
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long MobileNumber { get; set; }

        //Navigation Properties

        public IEnumerable<Order> Order { get; set; }
    }
}
