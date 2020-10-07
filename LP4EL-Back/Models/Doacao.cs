using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopJoin.API.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public Hospital Hospital { get; set; }
        public User User { get; set; }
        public DateTime Horario { get; set; }
        public Boolean Realizado { get; set; }

    }
}