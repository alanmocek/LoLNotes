using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    using Models;
    using System.Windows;
    using System.Windows.Input;

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

        private string searchValue = string.Empty;
        public string SearchValue
        {
            get
            {
                return searchValue;
            }
            set
            {
                searchValue = value;
                UpdateProperty(nameof(SearchValue));
            }
        }

        private ICommand searchChampionsCommand;
        public ICommand SearchChampions
        {
            get
            {
                if (searchChampionsCommand == null)
                    searchChampionsCommand = new RelayCommand(
                        (arg) =>
                        {
                            notesViewModel.Search(SearchValue);
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return searchChampionsCommand;
            }
        }

        private ICommand lostFocusCommand;
        public ICommand LostFocusCommand
        {
            get
            {
                if (lostFocusCommand == null)
                    lostFocusCommand = new RelayCommand(
                        (arg) =>
                        {
                            Keyboard.ClearFocus();
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return lostFocusCommand;
            }
        }
    }
}
