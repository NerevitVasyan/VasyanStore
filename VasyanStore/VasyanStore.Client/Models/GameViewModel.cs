using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VasyanStore.Client.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Display(Name="Назва гри:")]
        [Required(ErrorMessage = "Будьласка, введіть назву")]
        [StringLength(100)]
        [MinLength(2)]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Name { get; set; }

        [Display(Name = "Ціна:")]
        [Required(ErrorMessage = "Будьласка, введіть ціну")] 
        [Range(0,1000,ErrorMessage = "Ціна має бути додатня та не перевищувати 1000")]
        public double Price { get; set; }

        [Display(Name = "Дата виходу:")]
        [Required(ErrorMessage = "Будьласка, введіть дату виходу")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Виберіть жанр:")]
        [Required(ErrorMessage = "Будьласка, виберіть жанр")]
        public string Genre { get; set; }

        [Display(Name = "Виберіть розробника:")]
        [Required(ErrorMessage = "Будьласка, виберіть розробника")]
        public string Developer { get; set; }
    }
}