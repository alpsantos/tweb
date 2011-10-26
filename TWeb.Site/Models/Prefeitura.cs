using System.Collections.Generic;

namespace TWeb.Site.Models
{
    public class Prefeitura
    {
        public int Aderencia { get; set; }
        public byte[] Brasao { get; set; }
        public List<Documento> Documentos {get;set;}
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Nome { get; set; }
        public int Ordem { get; set; }
        public int StatusId { get; set; }
    }
}