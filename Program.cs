using starlink_cycle.Casting;
using starlink_cycle.Services;
using starlink_cycle.Scripting;
using starlink_cycle.Directing;


namespace starlink_cycle
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Snake snakeOne = new Snake();
            snakeOne.SnakePosition(Constants.MAX_X/7, Constants.MAX_Y/3, Constants.RED);

            Snake snakeTwo = new Snake();
            snakeTwo.SnakePosition(Constants.MAX_X-115, Constants.MAX_Y/3, Constants.GREEN);

            Cast cast = new Cast();
            cast.AddActor("snakeOne", snakeOne);
            cast.AddActor("snakeTwo", snakeTwo);
            cast.AddActor("snakeOneScore", new Score());
            cast.AddActor("snakeTwoScore", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
