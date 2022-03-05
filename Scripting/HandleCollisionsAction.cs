using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using starlink_cycle.Casting;
using starlink_cycle.Services;

namespace starlink_cycle.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Actions
    {
        private bool isGameOver = false;
        private string winner = "";

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleScoreUpdates(cast);
                HandleGameOver(cast);
            }
        }

        private string GetWinner()
        {
            return winner;
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleScoreUpdates(Cast cast)
        {
            Snake snakeOne = (Snake)cast.GetFirstActor("snakeOne");
            Snake snakeTwo = (Snake)cast.GetFirstActor("snakeTwo");
            Score snakeOneScore = (Score)cast.GetFirstActor("snakeOneScore");
            Score snakeTwoScore = (Score)cast.GetFirstActor("snakeTwoScore");
   
            int points = 1;
            snakeOne.GrowTail(points);
            snakeTwo.GrowTail(points);

            snakeOneScore.AddPoints(points);
            snakeTwoScore.AddPoints(points);
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snakeOne = (Snake)cast.GetFirstActor("snakeOne");
            Snake snakeTwo = (Snake)cast.GetFirstActor("snakeTwo");

            Actor snakeOneHead = snakeOne.GetHead();
            Actor snakeTwoHead = snakeTwo.GetHead();


            List<Actor> snakeOneBody = snakeOne.GetBody();
            List<Actor> snakeTwoBody = snakeTwo.GetBody();

            foreach (Actor segment in snakeOneBody)
            {
                if (segment.GetPosition().Equals(snakeTwoHead.GetPosition()))
                {
                    this.winner = "SnakeOne";
                    isGameOver = true;
                }
            }

            foreach (Actor segment in snakeTwoBody)
            {
                if (segment.GetPosition().Equals(snakeOneHead.GetPosition()))
                {
                    this.winner = "SnakeTwo";
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snakeOne = (Snake)cast.GetFirstActor("snakeOne");
                Snake snakeTwo = (Snake)cast.GetFirstActor("snakeTwo");

                List<Actor> snakeOneSegments = snakeOne.GetSegments();
                List<Actor> snakeTwoSegments = snakeTwo.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);
                string winner = this.GetWinner();

                Actor message = new Actor();
                message.SetText($"Game Over!\n{winner} Won!");
                message.SetColor(Constants.RED);
                message.SetFontSize(20);
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                // SnakeOne
                foreach (Actor segment in snakeOneSegments)
                {
                    segment.SetColor(Constants.WHITE);
                }

                // SnakeTwo
                foreach (Actor segment in snakeTwoSegments)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }

    }
}