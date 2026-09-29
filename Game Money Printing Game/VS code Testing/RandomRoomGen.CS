using System;

namespace RandomGen
{
    internal class Program
    {
        static void Main(string[] args)
        {            Console.WriteLine("Input a room type (Small, Medium, Large)");
            room = ConGenerator();
            gen.GenerateRoom(10, 10);
        }
    }

    internal class Generator
    {
        private readonly Random _random = new Random();
        public string GetRoomType()
        {

        }
        public (int width, int height) GetRoomSize()
        {
          var roomType = GetRoomType();
          if (roomType == "small")
          {
            return (width: _random.Next(3, 8), height: _random.Next(3, 8));
          }
          else if (roomType == "medium")
          {
            return (width: _random.Next(8, 16), height: _random.Next(8, 16));
          }
          else
          {
            return (width: 20, height: 20);
          }
        }
        public void GenerateRoom(int width, int height, int roomId)
        {
 
            var room = new char[width, height];
            string[][] roomBlocks = {{'+', '-'},{'#', '@'}, {'x', '%'}};
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    room[x, y] = roomBlocks[roomId][_random.Next(0, 2)];
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        room[x, y] = '+';
                    }
                    Console.Write(room[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}