using System.ComponentModel.DataAnnotations;

namespace ShopJoin.API.Dtos
{
    public class UserForRegisterDto
    {
        public string Tipo {get; set;}
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Documento {get; set;}
    }
}