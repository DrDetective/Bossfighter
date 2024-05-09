using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bossfighter
{
    internal class Data
    {
        //Player
        public static string playerName { get; set; }
        public int HP = 100;
        public int Damage = 10;
        public int Def = 10;
        public int Heal = 10;
        //Enemy
        public int HP_ENEMY = 100;
        public int Damage_ENEMY = 12;
        public int Def_Enemy = 15;
        public int round = 0;
        public List<string> EnNames = new List<string>();
        
        public Data()
        {
            EnNames.Add("Jellyfreak"); //enemy 1
            EnNames.Add("Pultridpod"); //nevim.png enemy 2
            EnNames.Add("Scareface"); //scoobs.png enemy 3
            EnNames.Add("Mindflayer"); //boss
        }
    }
}
