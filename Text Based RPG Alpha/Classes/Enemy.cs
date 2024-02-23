using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG_Alpha.Classes
{
    internal abstract class Enemy
    {
        public int HP { get; protected set; } // HP
        public int AttackDamage { get; protected set; } // Damage
        public (int x, int y) Position { get; protected set; } // Start area

        protected Enemy(int hp, int attackDamage, int startX, int startY) // Initialize enemy with it's custom stats
        {
            HP = hp;
            AttackDamage = attackDamage;
            Position = (startX, startY);
        }

        public void TakeDamage(int damage) // Take Damage from player
        {
            HP -= damage;
        }

        public abstract void Move(Map map); // Base class for enemy movement

        // Might add other methods here later idk
    }
}
