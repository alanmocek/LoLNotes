using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            Random ran = new Random();
            
            main = new MainViewModel();
        }
    }
}
