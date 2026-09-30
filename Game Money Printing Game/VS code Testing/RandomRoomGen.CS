using System;
using System.Data.Common;

namespace RandomGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Input a room type (Small, Medium, Large)");
            var gen = new Generator();
            var room = gen.GetRoomSize();
            gen.GenerateRoom(room.width, room.height, room.roomId);
        }
    }
    internal class Generator
    {
        private readonly Random _random = new Random();

        // This method randomly selects a room type from the predefined sizes.
        public string GetRoomType()
        {
            string[] size = { "small", "medium", "large" };
            int roomRoll = _random.Next(0, 3);
            return size[roomRoll];
        }

        // This method returns a tuple containing the width, height, and roomId based on the room type.
        public (int width, int height, int roomId) GetRoomSize()
        {
            var roomType = GetRoomType();
            if (roomType == "small")
            {
                return (width: _random.Next(3, 8), height: _random.Next(3, 30), roomId: 0);
            }
            else if (roomType == "medium")
            {
                return (width: _random.Next(8, 16), height: _random.Next(8, 80), roomId: 1);
            }
            else
            {
                return (width: 20, height: 120, roomId: 2);
            }
        }

        // This method generates a room based on the provided width, height, and roomId.
        public void GenerateRoom(int width, int height, int roomId)
        {

            var room = new string[width, height];
            string[,] roomBlocks = { { "+", "-" }, { "#", "@" }, { "x", "%" } };
            // for (int x = 0; x < width; x++)
            // {
            //     for (int y = 0; y < height; y++)
            //     {
            //         room[x, y] = roomBlocks[roomId, _random.Next(0, 2)];
            //     }
            // }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        room[x, y] = roomBlocks[roomId, 0];
                    }
                    else
                    {
                        room[x, y] = roomBlocks[roomId, 1];
                    }
                    Console.Write(room[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}