using System;

namespace TWeb.Portal.Models
{
    public class Post
    {
        public DateTime DataPublicacao { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public string Titulo { get; set; }
    }
}