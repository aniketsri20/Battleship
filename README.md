# Solution...
There is mutiple way to solve this problem-
1) Using 2d array
2) Using List

For both of the approcah we have to storing ship location in above collection.
As we have both ship and guesses location already so I have utilize existing value instead storing this.

Using Array:
var grid = new char[10, 10];
//and we can add ship location like
 grid[x, y] = 's'; 
 //Update ship location with fire Location
grid[x, y] = 'x'; 
then can take count

Using List :
We can create object of below class and store cordinate comma sperate string and hits in common seprated string for matching value.

class Ship
    {
        public string Name { get; set; }
        public direction Direction { get; set; }
        public string Hits { get; set; }
        public string Row { get; set; }
        public string Col { get; set; }
        public bool IsSunk
        {
            get
            {
                string comPareVal = Row;
                if (Direction == direction.horitzontal) comPareVal = Col;
                return comPareVal.Split(',').Length == Hits?.Split(',').Length;
            }
        }
 }

------------------------------------------------------------------------------------------------------------------
# Imagine a game of battleships...
The player has to guess the location of the opponent's 'ships' on a 10x10 grid. Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally. The player asks if a given co-ordinate is a hit or a miss. Once all cells representing a ship are hit - that ship is sunk.

## Ships
Each string represents a ship in the form first co-ordinate, last co-ordinate e.g. `"3:2,3:5"` is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
## Guesses 
Each string represents the co-ordinate of a guess e.g. `"7:0"` - misses the ship above, "3:3" hits it.
## Returns
The number of ships sunk by the set of guesses
