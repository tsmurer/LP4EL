using System.ComponentModel.DataAnnotations.Schema;

namespace ShopJoin.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pontos { get; set; }

    }
}