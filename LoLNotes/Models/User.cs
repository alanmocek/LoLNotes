﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLNotes.Models
{
    public class User
    {
        public string EmailAddress { private get; set; }
        public string Token { get; set; }

        public List<Champion> FavoriteChampions { get; set; } = new List<Champion>();

        public void Login(string emailAddress, string password)
        {

        }
    }
}
