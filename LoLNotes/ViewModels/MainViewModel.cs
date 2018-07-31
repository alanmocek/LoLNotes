using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    using Models;

    public class MainViewModel : BaseViewModel
    {
        private readonly User user;
        private NotesViewModel notesViewModel;
        private StartViewModel startViewModel;

        

        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                UpdateProperty(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            user = new User();

            notesViewModel = new NotesViewModel(user);
            startViewModel = new StartViewModel(user);

            AlanMocek.Communication.ConnectionManager.Url = "https://alanmocek.com/";

            CurrentViewModel = notesViewModel;
            //CurrentViewModel = startViewModel;
        }
    }
}
