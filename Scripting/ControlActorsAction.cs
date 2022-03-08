using starlink_cycle.Casting;
using starlink_cycle.Services;

namespace starlink_cycle.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Actions
    {
        private KeyboardService keyboardService;
        private Point snakeOneDirection = new Point(0, Constants.CELL_SIZE);
        private Point snakeTwoDirection = new Point(0, Constants.CELL_SIZE);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // SnakeOneControls
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                snakeOneDirection = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                snakeOneDirection = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                snakeOneDirection = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                snakeOneDirection = new Point(0, Constants.CELL_SIZE);
            }


            // SnakeTwoControls
            // left
            if (keyboardService.IsKeyDown("j"))
            {
                snakeTwoDirection = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                snakeTwoDirection = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                snakeTwoDirection = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                snakeTwoDirection = new Point(0, Constants.CELL_SIZE);
            } 


            Snake snakeOne = (Snake)cast.GetFirstActor("snakeOne");
            snakeOne.TurnHead(snakeOneDirection);

            Snake snakeTwo = (Snake)cast.GetFirstActor("snakeTwo");
            snakeTwo.TurnHead(snakeTwoDirection);
        }

    }
}