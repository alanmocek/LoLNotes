using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.Models
{
    public class MainNote : Note
    {
        public List<SubNote> SubNotes { get; set; } = new List<SubNote>();
    }
}
