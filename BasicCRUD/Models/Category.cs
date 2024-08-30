namespace BasicCRUD.Models
{
	public class Category
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        //public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
