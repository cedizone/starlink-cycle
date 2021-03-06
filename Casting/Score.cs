using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace starlink_cycle.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;
        

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score()
        {
            // AddPoints(this.name, 0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(string name, int points)
        {
            this.points += points;
            SetText($"{name}: {this.points}");
        }
    }
}