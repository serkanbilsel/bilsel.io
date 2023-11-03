﻿using System.ComponentModel.DataAnnotations;

namespace serkanbilsel.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} alanı Gereklidir")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        public string? Surname { get; set; }
        [EmailAddress, Required(ErrorMessage = "{0} alanı Gereklidir")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), DataType(DataType.MultilineText), Required(ErrorMessage = "{0} alanı Gereklidir")]
        public string Message { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
