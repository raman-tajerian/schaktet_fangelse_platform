using System;

namespace SchaktetFangelsePlatform
{

    public class Fange
    {
        // Properties
        public string Namn { get; private set; }
        public int HP { get; private set; }
        public int MaxHP { get; private set; }
        public int Attack { get; private set; }
        public int Forsvar { get; private set; }
        public int Level { get; private set; }
        public int XP { get; private set; }
        public int Dagar { get; private set; }
        public int Guld { get; private set; }

    internal class Fange
    {
    }
}





// Namn, HP, MaxHP, Attack, Försvar, Level, XP, Dagar överlevda - som fält/properties
// TakeDamage (int skada) minskar HP, returnerar en bool true om spelaren dör
// Heal() - Återställer HP till maxHP
// GainXP (int mängd) - lägger till XP, utlöser LevelUP() vid tröskel
// LevelUP() - Höjer level, ökar maxHP och attack, återställer HP
// Konstruktor med privata fält och properties (inte bara publika variabler)

// HP / maxHP = 100
// Attack = 10
// Försvar = 5
// Level = 1
// XP - tröskel för level up = 50 x nuvarande level
// Vid level up: +maxHP = +20
// Vid level up: + attack = 3
// Guld = 0
