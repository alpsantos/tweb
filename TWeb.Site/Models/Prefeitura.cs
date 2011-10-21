using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWeb.Site.Models
{
    public class Prefeitura
    {
        public string Nome { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Aderencia { get; set; }

        public int Ordem { get; set; }

        public int StatusId { get; set; }

        public byte[] Brasao { get; set; }

        public Documento Documento {get;set;}
    }

    
}