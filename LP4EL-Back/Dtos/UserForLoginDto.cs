namespace ShopJoin.API.Dtos
{
    public class UserForLoginDto
    {
        public string Name {get; set;}
        public string Tipo{ get;set; }
        public string Email { get; set; }
        public string Documento{ get; set; }
        public string Password { get; set; }
    }
}