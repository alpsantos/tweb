using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TWeb.Portal.Models
{
    public class RSS
    {
        private const string Url = "http://gpcgp.wordpress.com/feed/";
        public List<Post> LerPosts()
        {
            var posts = new List<Post>();

            var blogPires = new XmlDocument();

            try
            {
                blogPires.Load(Url);
                foreach (XmlNode node in blogPires.SelectNodes("rss/channel/item"))
                {
                    posts.Add(new Post
                    {
                        Titulo = node.SelectSingleNode("title").InnerText,
                        Link = node.SelectSingleNode("link").InnerText,
                        DataPublicacao = Convert.ToDateTime(node.SelectSingleNode("pubDate").InnerText),
                        Descricao = node.SelectSingleNode("description").InnerText
                    });
                }

                return posts.OrderByDescending(p => p.DataPublicacao).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}