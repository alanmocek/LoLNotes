using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    public class ViewModelLocator
    {
        private MainViewModel main;
        public MainViewModel Main
        {
            get
            {
                return main;
            }
        }

        public ViewModelLocator()
        {
            main = new MainViewModel();
        }
    }
}
