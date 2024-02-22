using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG_Alpha.Classes
{
    internal class Map
    {
        private char[,] mapLayout;

        public Map(string filePath)
        {
            LoadMap(filePath);
        }

        private void LoadMap(string filePath) // Load map from file
        {
            string[] lines = File.ReadAllLines(filePath);
            int width = lines[0].Length;
            int height = lines.Length;
            mapLayout = new char[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    mapLayout[y, x] = lines[y][x];
                }
            }
        }

        public void DisplayMap() // Displays the map
        {
            for (int y = 0; y < mapLayout.GetLength(0); y++)
            {
                for (int x = 0; x < mapLayout.GetLength(1); x++)
                {
                    Console.Write(mapLayout[y, x]);
                }
                Console.WriteLine();
            }
        }

        public bool IsWalkable(int x, int y)
        {
            return mapLayout[y, x] != '#' && mapLayout[y, x] != '~'; // Add simple wall dectection for now untill new map is made
        }
    }
}
