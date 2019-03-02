using System;


namespace Pacman
{
    class Game
    {
        /// <summary>
        /// This method is used to initialise the applicaiton.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game obj = new Game(); // Object to call the non static memeber of the class Game.
            obj.Start(); //Method call
        }
        
        private string facing { get; set; } // variable to hold the direction in which Pacman is facing.
        private int coordinateX { get; set; } // variable to hold X coordinate of the Pacman.
        private int coordinateY { get; set; } // variable to hold Y coordinate of the Pacman.
        private bool isPlaced { get; set; } // varibale to show Pacman holds valid position on the grid.
        private bool reportRestriction { get; set; } // variable to restrict report command, until Pacman has valid position on the grid.
        private int gridUpperLimit { get; set; } = 4; // Upper limit of the grid X,Y = 4. 5*5 units
        private int gridLowerLimit { get; set; } = 0; // Lower limit of the grid X,Y = 0. 

        /// <summary>
        /// This method is used to processed the user input and to initalise the critical elements of the application.
        /// </summary>
        public void Start()
        {
            isPlaced = false; // Initial value assign to false, since Pacman does not hold any valid position until now.
            reportRestriction = true; // Ignore report command until Pacman holds valid position on the grild, since reportRestriction equal to true
            string input;
            while (reportRestriction) // Seek user input until REPORT command is issused.
            {
                input = Console.ReadLine();
                input = input.ToUpper();
                input = input.Replace(@",", @" ");
                string[] processedInput = input.Split(' '); // Processed user input stored in array of string for easier manipulation.
                Execute(processedInput); // Execute  method call
            }
        }
        /// <summary>
        /// This method is reponsible for executing commands based on used input and uses switch statement to call repective method. 
        /// </summary>
        /// <param name="processedInput"></param>
        public void Execute(string[] processedInput)
        {
            int command = 0; // First index of the processedInput string array holds the command.
            switch (processedInput[command]) // Switch case to decided the flow of the program based on the command issused by the user.
            {
                case "PLACE":
                    Place(processedInput); // Place method call with processedInput as its parameters.
                    break;
                case "MOVE":
                    Move(); // Move method call.
                    break;
                case "LEFT":
                    Left(); // Left method call.
                    break;
                case "RIGHT":
                    Right(); // Right method call.
                    break;
                case "REPORT":
                    if (isPlaced) // If Pacman holds valid position on the grid, than lift report restriction.
                    {
                        reportRestriction = false;
                    }
                    Report(); // Report method call.
                    break;
                default:
                    break;

            }
        }
        /// <summary>
        /// This method is used to validate user input based on predefine constrainst like grid dimmesion and than place the Pacman on coressponding position.
        /// </summary>
        /// <param name="processedInput"></param>
        public void Place(string[] processedInput)
        {
            int x = 1; // Second index of the processedTnput[] holds X coordinate of Pacman. 
            int y = 2; // Third index of the processedTnput[] holds Y coordinate of Pacman. 
            int face = 3; // Fourth index of the processedTnput[] holds direction in which Pacman is facing. 
            int checkX; 
            int checkY;
            checkX = Int32.Parse(processedInput[x]); // Type conversion from string to int.
            checkY = Int32.Parse(processedInput[y]);
            if ((checkX >= gridLowerLimit && checkX <= gridUpperLimit) && (checkY >= gridLowerLimit && checkY <= gridUpperLimit))
            { // Condition to validate given X and Y coordinates fall under specified grid dimension. 
                isPlaced = true; // Pacman holds valid position on the grid.
                facing = processedInput[face]; // Update facing direction of Pacman.
                coordinateX = checkX; // Update X and Y coordinates
                coordinateY = checkY;
            }

        }
        /// <summary>
        /// This method uses switch statement to rotate Pacman left based on its current facing direction.
        /// </summary>
        public void Left()
        {
            switch (facing) // Rotate the Pacman left based on its current position.
            {
                case "NORTH":
                    facing = "WEST";
                    break;
                case "SOUTH":
                    facing = "EAST";
                    break;
                case "EAST":
                    facing = "NORTH";
                    break;
                case "WEST":
                    facing = "SOUTH";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// This method uses switch statement to rotate Pacman right based on its current facing direction.
        /// </summary>
        void Right()
        {
            switch (facing) // Rotate the Pacman right based on its current position.
            {
                case "NORTH":
                    facing = "EAST";
                    break;
                case "SOUTH":
                    facing = "WEST";
                    break;
                case "EAST":
                    facing = "SOUTH";
                    break;
                case "WEST":
                    facing = "NORTH";
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// This method is used to report the current postion of the Pacman on the grid in the specified format.
        /// </summary>
        public void Report()
        {
            if (reportRestriction) { } // Condition to check report restriction, which means REPORT command can not be executed untill Pacman hold valid position on the grid. 
            else
            {
                string output = "Output: " + coordinateX + "," + coordinateY + "," + facing;
                Console.WriteLine(output);
            }
        }
        /// <summary>
        /// This method is used to execute the MOVE command for the Pacman, it uses switch statement to organise different logic for
        /// MOVE command.
        /// </summary>
        public void Move()
        {
            int moveForward = 1;
            switch (facing)
            {
                case "NORTH":
                    if (coordinateY < gridUpperLimit) // Condition to check that Pacman is not on the northen most unit of the grid.
                    {
                        coordinateY = coordinateY + moveForward;
                    }
                    break;
                case "SOUTH":
                    if (coordinateY > gridLowerLimit) // Condition to check that Pacman is not on the southern most unit of the grid.
                    {
                        coordinateY = coordinateY - moveForward;
                    }
                    break;
                case "EAST":
                    if (coordinateX < gridUpperLimit) // Condition to check that Pacman is not on the eastern most unit of the grid.
                    {
                        coordinateX = coordinateX + moveForward;
                    }
                    break;
                case "WEST":
                    if (coordinateX > gridLowerLimit) // Condition to check that Pacman is not on the western most unit of the grid.
                    {
                        coordinateX = coordinateX - moveForward;
                    }
                    break;
                default:
                    break;
            }

        }



    }
    
}
