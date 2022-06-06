

using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class MoreThanOneWordValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null || fieldValue.Trim().IndexOf(" ") == -1)
            {
                return new ValidationResult("Il campo deve avere almeno due parole");
            }

            return ValidationResult.Success;
        }
    }
    public class Impiegato
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string PersonalWebSite { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }

    }

    public class ImpiegatoConFile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [MoreThanOneWordValidation]
        //si riferisce alla proprietà successiva a dove lo metto
        public string FullName { get; set; }
        public string Gender { get; set; }


        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(5, ErrorMessage = "la città non può avere più di 5 caratteri")]
        public string City { get; set; }
        public string? EmailAddress { get; set; }
        public string? PersonalWebSite { get; set; }
        public string? Photo { get; set; }
        public string? AlternateText { get; set; }
        public IFormFile File { get; set; }

    }

    public class EsitoOperazionePut
    {
        public string sEsito { get; set; }
    }


}
