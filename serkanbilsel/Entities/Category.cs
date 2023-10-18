using System.ComponentModel.DataAnnotations;

namespace serkanbilsel.Entities
{
    public class Category
    {
        [Display(Name = "Kategori Id")]
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Kategori Açıklaması")]
        public string? Description { get; set; }

    }
}
