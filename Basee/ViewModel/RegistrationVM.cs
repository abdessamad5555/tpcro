using System.ComponentModel.DataAnnotations;

namespace Basee.ViewModel
{
    public class registrationVM
    {
        [Required]
        public string login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string confpass { get; set; }

        [Required]
        public string nom { get; set; }

        [Required]
        public string prenom { get; set; }
    }
}
