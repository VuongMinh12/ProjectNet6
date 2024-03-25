namespace WebApplication3.Models
{
    public class BrandSearch
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
