using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    public class NotesViewModel : BaseViewModel
    {
        private User user;
        public static List<Champion> ChampionsDefinition = new List<Champion>()
        {
            new Champion("Jax","Jax"),
            new Champion("Sona","Sona"),
            new Champion("Tristana","Tristana"),
            new Champion("Varus","Varus"),
            new Champion("Kaisa","Kai'Sa"),
            new Champion("Fiora","Fiora"),
            new Champion("Singed","Singed"),
            new Champion("TahmKench","Tahm Kench"),
            new Champion("Leblanc","LeBlanc"),
            new Champion("Thresh","Thresh"),
            new Champion("Karma","Karma"),
            new Champion("Jhin","Jhin"),
            new Champion("Rumble","Rumble"),
            new Champion("Udyr","Udyr"),
            new Champion("LeeSin","Lee Sin"),
            new Champion("Yorick","Yorick"),
            new Champion("Ornn","Ornn"),
            new Champion("Kayn","Kayn"),
            new Champion("Kassadin","Kassadin"),
            new Champion("Sivir","Sivir"),
            new Champion("MissFortune","Miss Fortune"),
            new Champion("Draven","Draven"),
            new Champion("Yasuo","Yasuo"),
            new Champion("Kayle","Kayle"),
            new Champion("Shaco","Shaco"),
            new Champion("Renekton","Renekton") ,
            new Champion("Hecarim","Hecarim") ,
            new Champion("Fizz","Fizz"),
            new Champion("KogMaw","Kog'Maw"),
            new Champion("Maokai","Maokai"),
            new Champion("Lissandra","Lissandra"),
            new Champion("Jinx","Jinx"),
            new Champion("Urgot","Urgot"),
            new Champion("Fiddlesticks","Fiddlesticks"),
            new Champion("Galio","Galio"),
            new Champion("Pantheon","Pantheon"),
            new Champion("Talon","Talon"),
            new Champion("Gangplank","Gangplank"),
            new Champion("Ezreal","Ezreal"),
            new Champion("Gnar","Gnar"),
            new Champion("Teemo","Teemo"),
            new Champion("Annie","Annie"),
            new Champion("Mordekaiser","Mordekaiser"),
            new Champion("Azir","Azir"),
            new Champion("Kennen","Kennen"),
            new Champion("Riven","Riven"),
            new Champion("Chogath","Cho'Gath"),
            new Champion("Aatrox","Aatrox"),
            new Champion("Poppy","Poppy"),
            new Champion("Taliyah","Taliyah"),
            new Champion("Illaoi","Illaoi"),
            new Champion("Pyke","Pyke"),
            new Champion("Heimerdinger","Heimerdinger"),
            new Champion("Alistar","Alistar"),
            new Champion("XinZhao","Xin Zhao"),
            new Champion("Lucian","Lucian"),
            new Champion("Volibear","Volibear"),
            new Champion("Sejuani","Sejuani"),
            new Champion("Nidalee","Nidalee"),
            new Champion("Garen","Garen"),
            new Champion("Leona","Leona"),
            new Champion("Zed","Zed"),
            new Champion("Blitzcrank","Blitzcrank"),
            new Champion("Rammus","Rammus"),
            new Champion("Velkoz","Vel'Koz"),
            new Champion("Caitlyn","Caitlyn"),
            new Champion("Trundle","Trundle"),
            new Champion("Kindred","Kindred"),
            new Champion("Quinn","Quinn"),
            new Champion("Ekko","Ekko"),
            new Champion("Nami","Nami"),
            new Champion("Swain","Swain"),
            new Champion("Taric","Taric"),
            new Champion("Syndra","Syndra"),
            new Champion("Rakan","Rakan"),
            new Champion("Skarner","Skarner"),
            new Champion("Braum","Braum"),
            new Champion("Veigar","Veigar"),
            new Champion("Xerath","Xerath"),
            new Champion("Corki","Corki"),
            new Champion("Nautilus","Nautilus"),
            new Champion("Ahri","Ahri"),
            new Champion("Jayce","Jayce"),
            new Champion("Darius","Darius"),
            new Champion("Tryndamere","Tryndamere"),
            new Champion("Janna","Janna"),
            new Champion("Elise","Elise"),
            new Champion("Vayne","Vayne"),
            new Champion("Brand","Brand"),
            new Champion("Zoe","Zoe"),
            new Champion("Graves","Graves"),
            new Champion("Soraka","Soraka"),
            new Champion("Xayah","Xayah"),
            new Champion("Karthus","Karthus"),
            new Champion("Vladimir","Vladimir"),
            new Champion("Zilean","Zilean"),
            new Champion("Katarina","Katarina"),
            new Champion("Shyvana","Shyvana"),
            new Champion("Warwick","Warwick"),
            new Champion("Ziggs","Ziggs"),
            new Champion("Kled","Kled"),
            new Champion("Khazix","Kha'Zix"),
            new Champion("Olaf","Olaf"),
            new Champion("TwistedFate","Twisted Fate"),
            new Champion("Nunu","Nunu"),
            new Champion("Rengar","Rengar"),
            new Champion("Bard","Bard"),
            new Champion("Irelia","Irelia"),
            new Champion("Ivern","Ivern"),
            new Champion("MonkeyKing","Wukong"),
            new Champion("Ashe","Ashe"),
            new Champion("Kalista","Kalista"),
            new Champion("Akali","Akali"),
            new Champion("Vi","Vi"),
            new Champion("Amumu","Amumu"),
            new Champion("Lulu","Lulu"),
            new Champion("Morgana","Morgana"),
            new Champion("Nocturne","Nocturne"),
            new Champion("Diana","Diana"),
            new Champion("AurelionSol","Aurelion Sol"),
            new Champion("Zyra","Zyra"),
            new Champion("Viktor","Viktor"),
            new Champion("Cassiopeia","Cassiopeia"),
            new Champion("Nasus","Nasus"),
            new Champion("Twitch","Twitch"),
            new Champion("DrMundo","Dr. Mundo"),
            new Champion("Orianna","Orianna"),
            new Champion("Evelynn","Evelynn"),
            new Champion("RekSai","Rek'Sai"),
            new Champion("Lux","Lux"),
            new Champion("Sion","Sion"),
            new Champion("Camille","Camille"),
            new Champion("MasterYi","Master Yi"),
            new Champion("Ryze","Ryze"),
            new Champion("Malphite","Malphite"),
            new Champion("Anivia","Anivia"),
            new Champion("Shen","Shen"),
            new Champion("JarvanIV","Jarvan IV"),
            new Champion("Malzahar","Malzahar"),
            new Champion("Zac","Zac"),
            new Champion("Gragas","Gragas")
        };
        public static Champion GetChampion(string key)
        {
            foreach(Champion champ in ChampionsDefinition)
            {
                if(champ.Key == key)
                {
                    return champ;
                }
            }

            return null;
        }

        public NotesViewModel(User user)
        {
            this.user = user;
            InitLists();
        }

        private void InitLists()
        {
            bool favorite = false;
            foreach (Champion champ in ChampionsDefinition)
            {
                favorite = false;
                foreach (Champion favoriteChamp in user.UserFavoriteChampions)
                {
                    if (favoriteChamp == champ)
                    {
                        favorite = true;
                        break;
                    }
                }
                if (favorite)
                {
                    FavoriteChampions.Add(champ);
                }
                else
                {
                    AllChampions.Add(champ);
                }
            }
        }
        public void Search(string value)
        {
            if (value.Length < 2)
            {
                return;
            }
            OpenSearchChampsList();
            var lista = from c in ChampionsDefinition where (c.Name.ToLower()).Contains(value.ToLower()) select c;
            SearchChampions = lista.ToList();
            UpdateProperty(nameof(SearchChampions));
        }

        #region AppData
        private Champion selectedChampion;
        public Champion SelectedChampion
        {
            get
            {
                return selectedChampion;
            }
            set
            {
                selectedChampion = value;
                //UpdateProperty(nameof(SelectedChampion));
                UpdateProperty(nameof(CurrentMainNote));
                UpdateProperty(nameof(CurrentSubNote));
                UpdateProperty(nameof(CurrentSubNoteEnemiesList));
                UpdateProperty(nameof(NotesPanelVisibility));
                UpdateProperty(nameof(EnemiesListVisibility));
                UpdateProperty(nameof(EnemyNoteVisibility));
                UpdateProperty(nameof(IsSelectedChampionFavorite));
            }
        }

        private Champion selectedEnemy;
        public Champion SelectedEnemy
        {
            get
            {
                return selectedEnemy;
            }
            set
            {
                selectedEnemy = value;
                UpdateProperty(nameof(SelectedEnemy));
                UpdateProperty(nameof(CurrentSubNote));
                UpdateProperty(nameof(EnemyNoteVisibility));
            }
        }

        public MainNote CurrentMainNote
        {
            get
            {
                if (SelectedChampion is null)
                {
                    return null;
                }

                foreach (MainNote note in user.UserNotes)
                {
                    if (note.Champion == SelectedChampion)
                    {
                        return note;
                    }
                }

                MainNote newNote = new MainNote() { Champion = SelectedChampion };
                user.UserNotes.Add(newNote);

                return newNote;
            }
        }
        public SubNote CurrentSubNote
        {
            get
            {

                if (CurrentMainNote is null)
                {
                    return null;
                }

                foreach (SubNote note in CurrentMainNote.SubNotes)
                {
                    if (note.Champion == SelectedEnemy)
                    {
                        return note;
                    }
                }

                return null;
            }
        }

        public ObservableCollection<Champion> FavoriteChampions { get; set; } = new ObservableCollection<Champion>();
        public ObservableCollection<Champion> AllChampions { get; set; } = new ObservableCollection<Champion>();
        public List<Champion> SearchChampions { get; set; } = new List<Champion>();
        public ObservableCollection<Champion> CurrentSubNoteEnemiesList
        {
            get
            {
                if (CurrentMainNote is null)
                {
                    return null;
                }

                ObservableCollection<Champion> collection = new ObservableCollection<Champion>();

                foreach (SubNote note in CurrentMainNote.SubNotes)
                {
                    collection.Add(note.Champion);
                }

                return collection;
            }
        }

        
        #endregion

        #region Lists Visibility
        private bool favChampsListVisibility = true;
        public bool FavChampsListVisibility
        {
            get
            {
                return favChampsListVisibility;
            }
            set
            {
                favChampsListVisibility = value;
                UpdateProperty(nameof(FavChampsListVisibility));
            }
        }

        private bool allChampsListVisibility = true;
        public bool AllChampsListVisibility
        {
            get
            {
                return allChampsListVisibility;
            }
            set
            {
                allChampsListVisibility = value;
                UpdateProperty(nameof(AllChampsListVisibility));
            }
        }

        private bool searchChampsListVisibility = false;
        public bool SearchChampsListVisibility
        {
            get
            {
                return searchChampsListVisibility;
            }
            set
            {
                searchChampsListVisibility = value;
                UpdateProperty(nameof(SearchChampsListVisibility));
            }
        }

        private ICommand changeFavChampsListVisibilityCommand;
        private ICommand changeAllChampsListVisibilityCommand;
        private ICommand closeSearchChampsListCommand;

        public ICommand ChangeFavChampsListVisibilityCommand
        {
            get
            {
                if (changeFavChampsListVisibilityCommand is null)
                    changeFavChampsListVisibilityCommand = new RelayCommand(
                        (arg) =>
                        {
                            ChangeFavChampsListVisibility();
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return changeFavChampsListVisibilityCommand;
            }
        }
        public ICommand ChangeAllChampsListVisibilityCommand
        {
            get
            {
                if (changeAllChampsListVisibilityCommand is null)
                    changeAllChampsListVisibilityCommand = new RelayCommand(
                        (arg) =>
                        {
                            ChangeAllChampsListVisibility();
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return changeAllChampsListVisibilityCommand;
            }
        }
        public ICommand CloseSearchChampsListCommand
        {
            get
            {
                if (closeSearchChampsListCommand is null)
                    closeSearchChampsListCommand = new RelayCommand(
                        (arg) =>
                        {
                            CloseSearchChampsList();
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return closeSearchChampsListCommand;
            }
        }

        private void ChangeFavChampsListVisibility()
        {
            FavChampsListVisibility = !FavChampsListVisibility;
        }
        private void ChangeAllChampsListVisibility()
        {
            AllChampsListVisibility = !AllChampsListVisibility;
        }
        private void CloseSearchChampsList()
        {
            SearchChampsListVisibility = false;
        }
        private void OpenSearchChampsList()
        {
            SearchChampsListVisibility = true;
        }
        #endregion

        #region Notes Visibility
        public bool NotesPanelVisibility
        {
            get
            {
                if(SelectedChampion is null)
                {
                    return false;
                }

                return true;
            }
        }
        public bool EnemyNoteVisibility
        {
            get
            {
                if(SelectedEnemy is null)
                {
                    return false;
                }

                return true;
            }
        }
        public bool EnemiesListVisibility
        {
            get
            {
                if(CurrentMainNote is null)
                {
                    return false;
                }

                if (CurrentMainNote.SubNotes.Count < 1) 
                {
                    return false;
                }

                return true;
            }
        }
        #endregion

        #region EnemyOperations
        private ICommand addEnemyCommand;
        private ICommand removeEnemyCommand;

        public ICommand AddEnemyCommand
        {
            get
            {
                if (addEnemyCommand is null)
                    addEnemyCommand = new RelayCommand(
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            AddEnemy(champion);
                        },
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            if (champion is null)
                            {
                                return false;
                            }

                            return true;
                        });

                return addEnemyCommand;
            }
        }
        public ICommand RemoveEnemyCommand
        {
            get
            {
                if (removeEnemyCommand is null)
                    removeEnemyCommand = new RelayCommand(
                        (arg) =>
                        {
                            RemoveEnemy();
                        },
                        (arg) =>
                        {
                            if(CurrentSubNote is null)
                            {
                                return false;
                            }

                            return true;
                        });

                return removeEnemyCommand;
            }
        }

        private void AddEnemy( Champion champion)
        {
            if(SelectedChampion is null)
            {
                return;
            }

            foreach(SubNote note in CurrentMainNote.SubNotes)
            {
                if(note.Champion == champion)
                {
                    return;
                }
            }

            CurrentMainNote.SubNotes.Add(new SubNote() { Champion = champion });
            UpdateProperty(nameof(EnemiesListVisibility));
            UpdateProperty(nameof(CurrentSubNoteEnemiesList));
        }
        private void RemoveEnemy()
        {
            CurrentMainNote.SubNotes.Remove(CurrentSubNote);
            SelectedEnemy = null;
            UpdateProperty(nameof(CurrentSubNoteEnemiesList));
            UpdateProperty(nameof(SelectedEnemy));
            UpdateProperty(nameof(EnemyNoteVisibility));
            UpdateProperty(nameof(EnemiesListVisibility));
        }
        #endregion

        #region Selecting
        private ICommand selectChampCommand;
        private ICommand selectEnemyCommand;
        private ICommand deselectEnemyCommand;

        public ICommand SelectChampCommand
        {
            get
            {
                if (selectChampCommand == null)
                    selectChampCommand = new RelayCommand(
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            SelectChamp(champion);
                        },
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            if (champion == null)
                            {
                                return false;
                            }

                            return true;
                        });

                return selectChampCommand;
            }
        }
        public ICommand SelectEnemyCommand
        {
            get
            {
                if (selectEnemyCommand == null)
                    selectEnemyCommand = new RelayCommand(
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            SelectEnemy(champion);
                        },
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            if (champion == null)
                            {
                                return false;
                            }

                            return true;
                        });

                return selectEnemyCommand;
            }
        }
        public ICommand DeselectEnemyCommand
        {
            get
            {
                if (deselectEnemyCommand == null)
                    deselectEnemyCommand = new RelayCommand(
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            DeselectEnemy(champion);
                        },
                        (arg) =>
                        {
                            Champion champion = (Champion)arg;
                            if (champion == null)
                            {
                                return false;
                            }

                            return true;
                        });

                return deselectEnemyCommand;
            }
        }

        private void SelectChamp(Champion champion)
        {
            SelectedChampion = champion;
            SelectedEnemy = null;
        }
        private void SelectEnemy(Champion champion)
        {
            SelectedEnemy = champion;
        }
        private void DeselectEnemy(Champion champion)
        {
            if(SelectedEnemy == champion)
            {
                SelectedEnemy = null;
            }
        }
        #endregion

        #region Glyphs
        public bool IsSelectedChampionFavorite
        {
            get
            {
                if (SelectedChampion is null)
                {
                    return false;
                }

                foreach (Champion champ in user.UserFavoriteChampions)
                {
                    if (champ.Key == SelectedChampion.Key)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private ICommand changeFavoriteCommand;

        public ICommand ChangeFavoriteCommand
        {
            get
            {
                if (changeFavoriteCommand is null)
                    changeFavoriteCommand = new RelayCommand(
                        (arg) =>
                        {
                            ChangeFavorite();
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return changeFavoriteCommand;
            }
        }

        private void ChangeFavorite()
        {
            if (SelectedChampion == null)
            {
                return;
            }

            foreach (Champion champ in user.UserFavoriteChampions)
            {
                if (champ == SelectedChampion)
                {
                    user.UserFavoriteChampions.Remove(SelectedChampion);
                    FavoriteChampions.Remove(SelectedChampion);
                    AllChampions.Add(SelectedChampion);
                    UpdateProperty(nameof(IsSelectedChampionFavorite));
                    return;
                }
            }


            user.UserFavoriteChampions.Add(SelectedChampion);
            FavoriteChampions.Add(SelectedChampion);
            AllChampions.Remove(SelectedChampion);
            UpdateProperty(nameof(IsSelectedChampionFavorite));
        }
        #endregion

    }
}

