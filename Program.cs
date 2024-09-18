using SnakeGame;

Coordinates GridSize = new Coordinates(50, 20);
Coordinates SnakePosition = new Coordinates(10, 1);
Random rand = new Random();
Coordinates ApplePosition = new Coordinates(rand.Next(1, GridSize.X -1), rand.Next(1, GridSize.Y -1));
int FameDelayMS = 100;
Directions MovementDirection = Directions.down;
int score = 0;
List<Coordinates> SnakeHistory = new List<Coordinates>();
int Length = 1;



while(true)
{

    Console.Clear();
    SnakePosition.ApplyMovementChange(MovementDirection);
    Console.WriteLine("Score: " + score);
    for (int y = 0; y < GridSize.Y; y++)
    {
        for (int x = 0; x < GridSize.X; x++)
        {
            Coordinates CurrentCoordinates = new Coordinates(x, y);

            if (SnakePosition.Equals(CurrentCoordinates) || SnakeHistory.Contains(CurrentCoordinates))
                Console.Write("■");
            else if (ApplePosition.Equals (CurrentCoordinates))
                Console.Write("a");
            else if (x == 0 || y == 0 || x == GridSize.X - 1 || y == GridSize.Y - 1)
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

    if (SnakePosition.Equals(ApplePosition))
    {
        Length++;
        ApplePosition = new Coordinates(rand.Next(1, GridSize.X - 1), rand.Next(1, GridSize.Y - 1));
        score++;
    }
    else if (SnakePosition.X == 0 || SnakePosition.Y == 0 || SnakePosition.X == GridSize.X - 1 || SnakePosition.Y == GridSize.Y - 1 ||
        SnakeHistory.Contains(SnakePosition))
    {
        score = 0;
        Length = 1;
        SnakePosition = new Coordinates(10, 1);
        SnakeHistory.Clear();
        MovementDirection = Directions.down;
        continue;
    }

    SnakeHistory.Add(new Coordinates(SnakePosition.X, SnakePosition.Y));
    if(SnakeHistory.Count > Length)
    {
        SnakeHistory.RemoveAt(0);
    }    
    DateTime time = DateTime.Now;
    while ((DateTime.Now - time).Milliseconds < FameDelayMS)
    {
        if(Console.KeyAvailable)
        {
            ConsoleKey Input = Console.ReadKey(true).Key;


            switch (Input)
            {
                case ConsoleKey.LeftArrow:
                    MovementDirection = Directions.left;
                    break;
                case ConsoleKey.RightArrow:
                    MovementDirection = Directions.right;
                    break;
                case ConsoleKey.UpArrow:
                    MovementDirection = Directions.up;
                    break;
                case ConsoleKey.DownArrow:
                    MovementDirection = Directions.down;
                    break;
                case ConsoleKey.W:
                    MovementDirection = Directions.up;
                    break;
                case ConsoleKey.A:
                    MovementDirection = Directions.left;
                    break;
                case ConsoleKey.S:
                    MovementDirection = Directions.down;
                    break;
                case ConsoleKey.D:
                    MovementDirection = Directions.right;
                    break;
            }
        }
    }
}