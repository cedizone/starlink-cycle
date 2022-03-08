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
            // create the actors
            Snake snakeOne = new Snake();
            Snake snakeTwo = new Snake();
            Score snakeOneScore = new Score();
            Score snakeTwoScore = new Score();


            snakeOne.PrepareBody(new Point(150, 300), Constants.GREEN);
            snakeTwo.PrepareBody(new Point(750, 300), Constants.RED);
            snakeTwoScore.SetPosition(new Point(780, 0));

            Cast cast = new Cast();
            cast.AddActor("snakeOne", snakeOne);
            cast.AddActor("snakeTwo", snakeTwo);
            cast.AddActor("snakeOneScore", snakeOneScore);
            cast.AddActor("snakeTwoScore", snakeTwoScore);

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
