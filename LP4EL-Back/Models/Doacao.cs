using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopJoin.API.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public string Hospital { get; set; }
        public string User { get; set; }
        public DateTime Horario { get; set; }
        public Boolean Realizado { get; set; }

    }
}