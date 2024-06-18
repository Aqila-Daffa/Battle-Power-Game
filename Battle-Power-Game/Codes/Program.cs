using System;
using System.Xml.Linq;

namespace BattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battle Power game!");
            GamePlay gp = new GamePlay();
            gp.Play();
        }
    }
}