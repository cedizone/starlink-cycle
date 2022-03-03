using starlink_cycle.Casting;

namespace starlink_cycle.Scripting
{
    /// <summary>
    /// <para>A thing that is done.</para>
    /// <para>
    /// The responsibility of actions is to do something that is integral or important in the game. 
    /// Thus, it has one method, Execute(...), which should be overridden by derived classes.
    /// </para>
    /// </summary>
    public interface Actions
    {
        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actionss.</param>
        void Execute(Cast cast, Script script);
    }
}