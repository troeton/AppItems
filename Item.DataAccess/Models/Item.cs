namespace Item.DataAccess.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
    }
}
