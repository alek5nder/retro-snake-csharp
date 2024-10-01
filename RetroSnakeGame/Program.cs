using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RetroSnakeGame;
Coordination gridDimensions = new Coordination(50, 20);
Coordination snakePos = new Coordination(10, 1);
Random rand = new Random();
Coordination applePos = new Coordination(rand.Next(1,gridDimensions.X-1), rand.Next(1,gridDimensions.Y-1));
int FrameDelay = 200;
Direction movementDirection = Direction.Down;
List<Coordination> snakePosHistory = new List<Coordination>();
int tail = 1;
int score = 0;


while(true)
{
    Console.Clear();
    Console.WriteLine("Your score: " + score);
    snakePos.ApplyMovementDirection(movementDirection);
    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coordination currentCord = new Coordination(x, y);
            if (snakePos.Equals(currentCord) || snakePosHistory.Contains(currentCord))
            {
                Console.Write("o");
            }
            else if (applePos.Equals(currentCord))
            {
                Console.Write("a");
            }
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
    if(snakePos.Equals(applePos))
    {
        FrameDelay = FrameDelay - 10;
        score++;
        tail++;
        applePos = new Coordination(rand.Next(1,gridDimensions.X-1), rand.Next(1,gridDimensions.Y-1));
    }
    else if(snakePos.X == gridDimensions.X-1 || snakePos.X == 0 ||snakePos.Y== gridDimensions.Y-1 || snakePos.Y==0)
    {
        FrameDelay = 200;
        score = 0;
        tail = 1;
        snakePos = new Coordination(10, 1);
        snakePosHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }
    
    snakePosHistory.Add(new Coordination(snakePos.X,snakePos.Y));
    if(snakePosHistory.Count > tail)
    {
        snakePosHistory.RemoveAt(0);
    }
    DateTime time = DateTime.Now;

    while((DateTime.Now - time).Milliseconds < FrameDelay) {
    if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left; break;
                case ConsoleKey.RightArrow: movementDirection = Direction.Right; break;
                case ConsoleKey.UpArrow: movementDirection = Direction.Up; break;
                case ConsoleKey.DownArrow: movementDirection = Direction.Down; break;

            }
        }
    }
    
}
