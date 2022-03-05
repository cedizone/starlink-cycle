using System.Collections.Generic;
using starlink_cycle.Casting;
using starlink_cycle.Services;

namespace starlink_cycle.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Actions
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snakeOne = (Snake)cast.GetFirstActor("snakeOne");
            Snake snakeTwo = (Snake)cast.GetFirstActor("snakeTwo");

            List<Actor> snakeOneSegments = snakeOne.GetSegments();
            List<Actor> snakeTwoSegments = snakeTwo.GetSegments();

            Actor snakeOneScore = cast.GetFirstActor("snakeOneScore");
            Actor snakeTwoScore = cast.GetFirstActor("snakeTwoScore");

            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(snakeOneSegments);
            videoService.DrawActors(snakeTwoSegments);

            videoService.DrawActor(snakeOneScore);
            videoService.DrawActor(snakeTwoScore);

            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}