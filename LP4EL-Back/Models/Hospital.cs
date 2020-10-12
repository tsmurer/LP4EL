using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopJoin.API.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }

        //public Boolean Autorizado { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}