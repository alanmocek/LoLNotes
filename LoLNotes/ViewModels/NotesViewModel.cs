using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    using Models;

    public class NotesViewModel : BaseViewModel
    {
        private User user;

        public NotesViewModel(User user)
        {
            this.user = user;
        }
    }
}
