using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAsyncIO
{
    public static class GameCreator
    {
        static string[] actors = { "Archer", "Footman", "Knight", "Castle", "Rider", "Catapult" };

        static int[] forceValues = { 100, 200, 300, 400 };

        static string[] types = { "Human", "Computer", "Ghost" };

        static string[] mainlands = { "Mordor", "Middle Earth", "Other Side", "Wrong Side", "Red Zone", "Deadly Land", "Kolburg" };

        internal static List<GameElement> CreateRandomElements(int size)
        {
            List<GameElement> elements = new List<GameElement>(size);

            Random randomzier = new Random();

            for (int i = 0; i < size; i++)
            {
                GameElement element = new GameElement();
                element.Id = i;
                element.Actor = actors[randomzier.Next(0, actors.Length - 1)];
                element.Force = forceValues[randomzier.Next(0, forceValues.Length - 1)];
                element.MainLand = mainlands[randomzier.Next(0, mainlands.Length - 1)];
                element.Type = types[randomzier.Next(0, types.Length - 1)];
                element.X = randomzier.Next(-90, 90);
                element.Y = randomzier.Next(-90, 90);

                elements.Add(element);
            }

            return elements;
        }
    }
}
