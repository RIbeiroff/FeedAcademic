using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Model.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Resposta
    {
        public List<KeyValuePair<string, List<string>>> Perguntas { get; set; }
        public Dictionary<string, string> Respostas { get; set; }

        public Resposta Add(string key, string[] value)
        {
            Perguntas.Add(new KeyValuePair<string, List<string>>(key, value.ToList()));
            return this;
        }

        public Resposta()
        {
            Respostas = new Dictionary<string, string>();
            Perguntas = new List<KeyValuePair<string, List<string>>>();
        }
    }
}   
