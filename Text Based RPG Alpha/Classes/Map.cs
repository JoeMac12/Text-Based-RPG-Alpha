using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG_Alpha.Classes
{
    internal class Map // Initialize
    {
        private char[,] mapData;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(string filePath)
        {
            LoadMap(filePath);
        }

        private void LoadMap(string filePath) // Load the map from the text file
        {
            string[] lines = File.ReadAllLines(filePath);
            Height = lines.Length;
            Width = lines[0].Length;
            mapData = new char[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    mapData[x, y] = lines[y][x];
                }
            }
        }

        public char GetTile(int x, int y) // Make walls
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return '#';
            return mapData[x, y];
        }

        public bool IsWalkable(int x, int y)
        {
            char tile = GetTile(x, y);
            return tile != '#' && tile != '~'; // Wall and acid check
        }

        public void Render() // Display the map
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    char tile = mapData[x, y];
                    switch (tile) // Set colors for each tiles
                    {
                        case '#':
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case '~':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write(tile);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
