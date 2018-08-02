using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.Models
{
    public abstract class Note
    {
        public Champion Champion { get; set; }
        public string Text { get; set; }
    }
}
