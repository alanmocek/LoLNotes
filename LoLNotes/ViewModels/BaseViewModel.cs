using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public delegate void ViewModelEventHandler();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void UpdateProperty(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
