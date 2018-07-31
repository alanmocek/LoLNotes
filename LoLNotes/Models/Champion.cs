using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.Models
{
    public class Champion
    {
        public Champion() { }
        public Champion(string key, string name)
        {
            this.Key = key;
            this.Name = name;
        }

        public string Name { get; set; }
        public string Key { get; set; }
        public string IconPath
        {
            get
            {
                return "/Resources/Champions/Icons/" + Key + ".png";
            }
        }
    }
}
