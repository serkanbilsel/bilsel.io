using System.ComponentModel.DataAnnotations;

namespace serkanbilsel.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name = "Mesajınız :"), DataType(DataType.MultilineText), Required(ErrorMessage = "{0} Boş Geçilemez.!")]
        public required string Comments { get; set; }
        [Display(Name ="Beğeni Sayısı :")]
        public int LikeCount { get; set; }
        [Display(Name = "Eklenme Tarihi :"), ScaffoldColumn(false)] // diğer sayfalarda gelmesin diye scaff yaptık
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [Display(Name = "Onay Durumu :")]
        public bool Approved { get; set; } // Onaylandı mı?
    }
}

