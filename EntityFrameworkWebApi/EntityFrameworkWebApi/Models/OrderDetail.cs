namespace EntityFrameworkWebApi.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        //Navigate
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}