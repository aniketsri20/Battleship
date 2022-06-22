using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] ships, string[] guesses)
        {
            return ShunkShipCount(ships, guesses);
        }

        static int ShunkShipCount(string[] ships, string[] guesses)
        {
            if (ships == null || guesses == null || guesses.Length == 0 || ships.Length == 0)
            {
                Console.WriteLine("ships or guesses is missing");
                return 0;
            }

            string strRegex = @"([0-9]+[:]+[0-9]+[,][0-9]+[:]+[0-9]+)";
            Regex re = new Regex(strRegex);
            int count = 0;
            for (int i = 0; i < ships.Length; i++)
            {
                if (re.IsMatch(ships[i]))
                {
                    var cod = ships[i].Split(',');
                    var c1 = cod[0].Split(':');
                    var c2 = cod[1].Split(':');

                    int x1 = int.Parse(c1[0]);
                    int y1 = int.Parse(c1[1]);
                    int x2 = int.Parse(c2[0]);
                    int y2 = int.Parse(c2[1]);

                    if (x1 == x2 && ((y1 - y2) > 1 || (y1 - y2) < 5))
                    {
                        var shipArrayCordinate = Enumerable.Range(y1, y2 - y1 + 1).Select(y => $"{x1}:{y}").ToArray();
                        if (guesses.IntersectCount(shipArrayCordinate) == shipArrayCordinate.Count()) count++;
                    }
                    else if (y1 == y2 && ((x1 - x2) > 1 || (x1 - x2) < 5))
                    {
                        var shipArrayCordinate = Enumerable.Range(x1, x2 - x1 + 1).Select(x => $"{x}:{y1}").ToArray();
                        if (guesses.IntersectCount(shipArrayCordinate) == shipArrayCordinate.Count()) count++;
                    }
                    else Console.WriteLine($"ships co-ordinate is invalid {ships[i]} or ship length is not in range 2-4");

                }
                else Console.WriteLine("Please provide ship coordinate in proper format");
            }

            return count;
        }

    }
    public static class CollectionExtensions
    {

        public static int IntersectCount(this string[] firstArray, string[] secondArray)
        {
            int count = 0;
            if (firstArray == null || secondArray == null || firstArray.Length == 0 || secondArray.Length == 0)
            {
                return count;
            }

            for (var i = 0; i < secondArray.Length; i++)
            {

                if (firstArray.(secondArray[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
