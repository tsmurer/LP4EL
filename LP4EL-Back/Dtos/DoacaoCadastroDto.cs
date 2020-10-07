using System;
using System.ComponentModel.DataAnnotations;

namespace ShopJoin.API.Dtos
{
    public class DoacaoCadastroDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdHospital { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public DateTime Horario { get; set; }
        [Required]
        public Boolean Realizado { get; set; }

    }
}