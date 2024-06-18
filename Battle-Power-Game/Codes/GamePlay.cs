using System;

namespace BattleGame
{
    class GamePlay
    {
        public string CharName()
        {
            Console.WriteLine("Put your hero name?");
            string charName = Console.ReadLine();
            return charName;
        }

        public int AttPower()
        {
            int attPower = 0;
            Console.WriteLine("\nChoose Your Attack Power: \na. 15 \nb. 20");
            string attackAns = Console.ReadLine();

            while ((attackAns != "a") && (attackAns != "b"))
            {
                Console.WriteLine("\nPlease choose between 'a' or 'b'");
                attackAns = Console.ReadLine();
            }

            if (attackAns == "a")
            {
                attPower += 15;
            }
            else
            {
                attPower += 20;
            }

            return attPower;
        }

        public int HealPower(int attPower)
        {
            int healPow = 0;
            if (attPower == 15)
            {
                healPow += 20;
            }
            else
            {
                healPow += 15;
            }

            return healPow;
        }

        public void Play()
        {
            bool isPlayer1 = false;
            int turn = 0;
            int round = 1;
            Console.WriteLine("Player 1:");
            string name1 = CharName();
            int atPow1 = AttPower();
            int hlPw1 = HealPower(atPow1);

            Character player1 = new Character(name1, atPow1, hlPw1);
            Console.WriteLine($"\nPlayer1 hero: \nName = {name1} \nAttack Power = {atPow1} \nHeal Power = {hlPw1}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Player 2:");
            string name2 = CharName();
            int atPow2 = AttPower();
            int hlPw2 = HealPower(atPow2);

            Character player2 = new Character(name2, atPow2, hlPw2);
            Console.WriteLine($"\nPlayer2 hero: \nName = {name2} \nAttack Power = {atPow2} \nHeal Power = {hlPw2}");

            while ((player1.currentHP > 0) && (player2.currentHP > 0))
            {
                if(turn%2 == 0 && turn != 0)
                {
                    round++;
                }

                if(turn == 0 || turn % 2 == 0 )
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"------------------------------ Round {round} ------------------------------");
                }              
                
                Console.WriteLine();
                Console.WriteLine($"{name1} HP = {player1.currentHP}\n{name2} HP = {player2.currentHP}");

                if (!isPlayer1)
                {
                    Console.WriteLine($"\n{name1}'s move: \na. Attack \nb. Heal");
                    string move1 = Console.ReadLine();

                    while ((move1 != "a") && (move1 != "b"))
                    {
                        Console.WriteLine("\nPlease choose between 'a' or 'b'");
                        move1 = Console.ReadLine();
                    }
                    if(move1 == "a")
                    {
                        Console.WriteLine();
                        player1.Attack(player2);
                    }else
                    {
                        Console.WriteLine();
                        player1.Heal();
                    }
                    turn++;
                    isPlayer1 = true;
                }
                else
                {
                    Console.WriteLine($"\n{name2}'s move: \na. Attack \nb. Heal");
                    string move2 = Console.ReadLine();

                    while ((move2 != "a") && (move2 != "b"))
                    {
                        Console.WriteLine("\nPlease choose between 'a' or 'b'");
                        move2 = Console.ReadLine();
                    }
                    if (move2 == "a")
                    {
                        Console.WriteLine();
                        player2.Attack(player1);
                    }
                    else
                    {
                        Console.WriteLine();
                        player2.Heal();
                    }
                    turn++;
                    isPlayer1 = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"------------------------------ Round {round} ------------------------------");
            Console.WriteLine();
            Console.WriteLine($"{name1} HP = {player1.currentHP}\n{name2} HP = {player2.currentHP}");
            Console.WriteLine();

            if (player1.currentHP < 1)
            {
                Console.WriteLine($"{name1} is defeated by {name2} \nPlayer 2 win");
            }
            else
            {
                Console.WriteLine($"{name2} is defeated by {name1} \nPlayer 1 win");
            }

        }

    }
}
