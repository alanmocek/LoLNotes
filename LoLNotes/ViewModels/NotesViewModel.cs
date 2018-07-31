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

        public ObservableCollection<Champion> FavoriteChampions { get; set; } = new ObservableCollection<Champion>();
        public ObservableCollection<Champion> AllChampions { get; set; } = new ObservableCollection<Champion>();

        public readonly List<Champion> ChampionsDefinition = new List<Champion>()
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

        public NotesViewModel(User user)
        {
            this.user = user;
            user.FavoriteChampions.Add(ChampionsDefinition[0]);
            user.FavoriteChampions.Add(ChampionsDefinition[1]);
            InitLists();
        }

        private void InitLists()
        {
            bool favorite = false;
            foreach (Champion champ in ChampionsDefinition)
            {
                favorite = false;
                foreach (Champion favoriteChamp in user.FavoriteChampions)
                {
                    if (favoriteChamp == champ)
                    {
                        favorite = true;
                        break;
                    }
                }
                if(favorite)
                {
                    FavoriteChampions.Add(champ);
                }else
                {
                    AllChampions.Add(champ);
                }
            }
        }

        private bool favChamsListVisibility = true;
        public bool FavChamsListVisibility
        {
            get
            {
                return favChamsListVisibility;
            }
            set
            {
                favChamsListVisibility = value;
                UpdateProperty(nameof(FavChamsListVisibility));
            }
        }

        private bool allChamsListVisibility = true;
        public bool AllChamsListVisibility
        {
            get
            {
                return allChamsListVisibility;
            }
            set
            {
                allChamsListVisibility = value;
                UpdateProperty(nameof(AllChamsListVisibility));
            }
        }

        private ICommand hideFavoriteChampionsCommand;
        public ICommand HideFavoriteChampions
        {
            get
            {
                if (hideFavoriteChampionsCommand == null)
                    hideFavoriteChampionsCommand = new RelayCommand(
                        (arg) =>
                        {
                            FavChamsListVisibility = !FavChamsListVisibility;
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return hideFavoriteChampionsCommand;
            }
        }

        private ICommand hideAllChampionsCommand;
        public ICommand HideAllChampions
        {
            get
            {
                if (hideAllChampionsCommand == null)
                    hideAllChampionsCommand = new RelayCommand(
                        (arg) =>
                        {
                            AllChamsListVisibility = !AllChamsListVisibility;
                        },
                        (arg) =>
                        {
                            return true;
                        });

                return hideAllChampionsCommand;
            }
        }
    }
}
