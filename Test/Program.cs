using Test;

Main();

int Main()
{
    try
    {
        Console.WriteLine("Input the field params");

        var fieldParams = Console.ReadLine().Split(' ');

        var fieldX = int.Parse(fieldParams[0]);
        var fieldY = int.Parse(fieldParams[1]);

        if (fieldX < 0 || fieldY < 0)
        {
            Console.WriteLine("Field dimensions cannot be negative");
            return -1;
        }
        if (fieldX > 50 || fieldY > 50)
        {
            Console.WriteLine("Field dimensions cannot be more than 50");
            return -1;
        }
        
        var field = new Field(fieldX, fieldY);

        while (true)
        {
            Console.WriteLine("Input robot params");

            var robotParams = Console.ReadLine().ToUpper().Split(' ');

            var robotX = int.Parse(robotParams[0]);
            var robotY = int.Parse(robotParams[1]);
            var robotDimension = char.Parse(robotParams[2]);

            if (robotX < 0 || robotY < 0)
            {
                Console.WriteLine("Input position cannot be negative");
                return -1;
            }

            if (robotX > 50 || robotY > 50)
            {
                Console.WriteLine("Robot position cannot be more than 50");
                return -1;
            }

            var dirs = "NSEW";
            if (!dirs.Contains(robotDimension))
            {
                Console.WriteLine("Direction should be in N S E W");
                return -1; 
            }

            var robot = new Robot(robotX, robotY, robotDimension);

            Console.WriteLine("Input move params");

            var moveParams = Console.ReadLine().ToUpper().ToCharArray();

            if (moveParams.Length > 100)
            {
                Console.WriteLine("Instruction should be less than 100 characters");
                return -1;
            }

            var instructions = "RLF";
            
            foreach (var moveParam in moveParams)
            {
                if (!instructions.Contains(moveParam))
                {
                    Console.WriteLine("Instruction should be in R L F");
                    return -1; 
                }

                switch (moveParam)
                {
                    case 'F':
                        robot.Move(moveParam);
                        break;
                    default:
                        robot.Rotate(moveParam);
                        break;
                }

                if (robot.CheckLost(field))
                {
                    break;
                }

            }

            if (robot.IsLost)
            {
                Console.WriteLine($"{robot.X} {robot.Y} {robot.Direction} LOST");
            }
            else
            {
                Console.WriteLine($"{robot.X} {robot.Y} {robot.Direction}");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}

