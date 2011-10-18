using System;

namespace TWeb.Portal.Models
{
    public class Post
    {
        public string Titulo { get; set; }
        public string Link { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Descricao { get; set; }
    }
}