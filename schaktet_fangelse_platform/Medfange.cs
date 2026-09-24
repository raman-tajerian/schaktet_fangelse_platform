using System;
using System.Collections.Generic;
using System.Text;

namespace schaktet_fangelse_platform
{
    internal abstract class Medfange
    {
        public string Namn { get; private set; }
        public int HP { get; private set; }
        public int Attack { get; private set; }
        public int XPBeloning { get; private set; }
        public int GuldMin { get; private set; }
        public int GuldMax { get; private set; }


        protected Medfange(string namn, int hp, int attack, int xpBeloning, int guldMin, int guldMax)
        {
            Namn = namn;
            HP = hp;
            Attack = attack;
            XPBeloning = xpBeloning;
            GuldMin = guldMin;
            GuldMax = guldMax;
        }
        public bool TakeDamage(int skada)
        {
            HP = HP - skada;
            if (HP <= 0)
                return true;
            else
                return false;
        }

    }
}
