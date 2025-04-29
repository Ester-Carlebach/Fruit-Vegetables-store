namespace Dto
{
    public class Category
    {
        public int CatId { get; set; }

        public string CatName { get; set; } = null!;
        public int? CompId { get; set; }
        public string? CompName { get; set; }
        //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
