using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG_Alpha.Classes
{
    internal class Player
    {
        public int HP { get; private set; } = 20; // Set base values 
        public int ShieldHealth { get; private set; } = 10;
        public int AttackDamage { get; private set; } = 2;
        public (int x, int y) Position { get; private set; }

        public Player(int startX, int startY)
        {
            Position = (startX, startY); // Start position
        }

        public void Move(char direction, Map map) // Player movement controls
        {
            int newX = Position.x;
            int newY = Position.y;

            switch (direction)
            {
                case 'W': // Up
                    newY--;
                    break;
                case 'S': // Down
                    newY++;
                    break;
                case 'A': // Left
                    newX--;
                    break;
                case 'D': // Right
                    newX++;
                    break;
            }

            if (map.IsWalkable(newX, newY)) // Check if the spot is walkable
            {
                Position = (newX, newY);
                CheckForItems(map, newX, newY);
            }
            else if (map.GetTile(newX, newY) == '~') // Check if it's acid
            {
                TakeDamage(1); // Acid pool damage
            }
            // TODO... Attacking and picking up
        }

        private void CheckForItems(Map map, int x, int y)
        {
            // TODO... Check for items
        }

        public void Attack(Enemy enemy)
        {
            enemy.TakeDamage(AttackDamage);
        }

        public void TakeDamage(int damage) // Shield absorbs damage first
        {
            if (ShieldHealth > 0)
            {
                ShieldHealth -= damage;
                if (ShieldHealth < 0)
                {
                    HP += ShieldHealth; // Apply the rest of the damage to health
                    ShieldHealth = 0;
                }
            }
            else
            {
                HP -= damage;
            }
        }

        public void UseItem(Item item)
        {
            // TODO... Trigger the Item when collecting it
        }
    }
}
