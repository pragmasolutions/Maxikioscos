using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Email.Models
{
    public class ReportarErrorModel
    {
        [Required(ErrorMessage = "Debe ingresar un email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "El email ingresado no es válido")]
        [Display(Name = "Email:")]
        public string EmailAddress { get; set; }

        [Display(Name = "Título:")]
        [Required(ErrorMessage = "Debe ingresar un título")]
        public string Titulo { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        public string Description { get; set; }

        public int? TicketErrorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WebUrl { get; set; }
    }
}