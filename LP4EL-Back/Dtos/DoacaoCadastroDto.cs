using System;
using System.ComponentModel.DataAnnotations;

namespace ShopJoin.API.Dtos
{
    public class DoacaoCadastroDto
    {
        [Required]
        public int IdHospital { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public DateTime Horario { get; set; }
        public Boolean Realizado { get; set; }

    }
}