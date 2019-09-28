

namespace Dick.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum Lista
    {
        Jugar,
        Justicia,
        Jalar
    }

    public class Clown
    {
        [Key]
        public int ClownID { get; set; }

        [Required]
        [Display(Description = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string NickName { get; set; }

        [Required]
        public Lista Tricks { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Por favor, ingresar solo correos")]
        public string Email { get; set; }

        [Display(Description = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }


    }
}