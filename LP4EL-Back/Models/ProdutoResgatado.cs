using System.ComponentModel.DataAnnotations.Schema;

namespace ShopJoin.API.Models
{
    public class ProdutoResgatado
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public User User { get; set; }

        public string Codigo {get; set;}

    }
}