using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace LoLNotes.Models
{
    public class Saver
    {
        public List<FavoriteChampionSaver> favoriteChampions;
        public List<NoteSaver> notes;

        [NonSerialized]
        public string fileName = "userdata.xml"; 
        [NonSerialized]
        XmlSerializer serializer;

        public Saver()
        {
            serializer = new XmlSerializer(typeof(Saver));
        }

        public class FavoriteChampionSaver
        {
            public string Key { get; set; }
        }

        public class NoteSaver
        {
            public string Key { get; set; }
            public string Text { get; set; }

            public List<SubNoteSaver> Subnotes { get; set; }
        }

        public class SubNoteSaver
        {
            public string Key { get; set; }
            public string Text { get; set; }
        }

        public void Save(User user)
        {
            if(user.UserFavoriteChampions.Count>0)
            {
                favoriteChampions = new List<FavoriteChampionSaver>();

                foreach(Champion champ in user.UserFavoriteChampions)
                {
                    favoriteChampions.Add(new FavoriteChampionSaver() { Key = champ.Key });
                }
            }

            if(user.UserNotes.Count>0)
            {
                notes = new List<NoteSaver>();

                foreach(MainNote mainNote in user.UserNotes)
                {
                    NoteSaver noteSaver = new NoteSaver() { Key = mainNote.Champion.Key, Text = mainNote.Text };
                    
                    if(mainNote.SubNotes.Count>0)
                    {
                        noteSaver.Subnotes = new List<SubNoteSaver>();

                        foreach (SubNote subNote in mainNote.SubNotes)
                        {
                            noteSaver.Subnotes.Add(new SubNoteSaver() { Key = subNote.Champion.Key, Text = subNote.Text });
                        }
                    }

                    notes.Add(noteSaver);
                }
            }

            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, this);
        }

        public void Load(User user)
        {
            TextReader reader = new StreamReader(fileName);
            Saver loadedData = (Saver)serializer.Deserialize(reader);

            foreach(FavoriteChampionSaver favChamp in loadedData.favoriteChampions)
            {
                bool addFavoriteChamp = true;
                Champion champ = ViewModels.NotesViewModel.GetChampion(favChamp.Key);
                if (champ != null)
                {
                    foreach(Champion existingFavChamp in user.UserFavoriteChampions)
                    {
                        if(existingFavChamp == champ)
                        {
                            addFavoriteChamp = false;
                        }
                    }

                    if(addFavoriteChamp)
                    {
                        user.UserFavoriteChampions.Add(champ);
                    }
                }
            }

            foreach(NoteSaver note in loadedData.notes)
            {
                bool addMainNote = true;
                Champion champMainNote = ViewModels.NotesViewModel.GetChampion(note.Key);
                if (champMainNote != null)
                {
                    foreach(MainNote mainNote in user.UserNotes)
                    {
                        if(mainNote.Champion.Key == champMainNote.Key)
                        {
                            addMainNote = false;
                            break;
                        }
                    }
                }else
                {
                    addMainNote = false;
                }

                if(addMainNote)
                {
                    MainNote newMainNote = new MainNote() { Champion = champMainNote, Text = note.Text };

                    foreach (SubNoteSaver subNote in note.Subnotes)
                    {
                        Champion champSubNote = ViewModels.NotesViewModel.GetChampion(subNote.Key);

                        foreach(SubNote existingSubNote in newMainNote.SubNotes)
                        {
                            if(existingSubNote.Champion.Key == champSubNote.Key)
                            {
                                champSubNote = null;
                            }
                        }

                        if (champSubNote != null)
                        {
                            newMainNote.SubNotes.Add(new SubNote() { Champion = champSubNote, Text = subNote.Text });
                        }
                    }

                    user.UserNotes.Add(newMainNote);
                }
            }
        }
    }
}
