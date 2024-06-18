using System;

namespace BattleGame
{
    class Character
    {
        private int maxHP;
        private string charName;
        private int attackPower;
        private int healPower;
        public int currentHP;
        private Random random;

        public void Start()
        {
            Console.WriteLine("Let's start the battle!");
        }

        public Character(string charName, int attackPower, int healPower)
        {
            this.charName = charName;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.maxHP = 100;
            this.currentHP = maxHP;
            this.random = new Random();
        }

        public override string ToString()
        {
            return $"Character Name: {charName} \nTotal HP: {currentHP} \nAttack Power: {attackPower} \nHeal Powe: {healPower}";
        }

        public void Attack(Character charAttacked)
        {
            int range = random.Next(1, 4);
            int damage = attackPower * range;
            Attacked(charAttacked, damage);

            Console.WriteLine($"{charName} attacks {charAttacked.charName} with the damage of {damage}, {charAttacked.charName}'s current HP: {charAttacked.currentHP}");
        }

        public void Attacked(Character charAttacked, int damage)
        {
            charAttacked.currentHP -= damage;
            if(charAttacked.currentHP <= 0)
            {
                charAttacked.currentHP = 0;
            }
        }

        public void Heal()
        {
            int range = random.Next(1, 2);
            int healed = healPower * range;
            currentHP += healed;

            if(currentHP > maxHP)
                currentHP = maxHP;

            Console.WriteLine($"{charName} is healed with the HP of {healed}, {charName}'s current HP: {currentHP}");
        }
    }
}