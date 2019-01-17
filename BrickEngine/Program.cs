using BrickEngine.Core;
using BrickEngine.Utility;

namespace BrickEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine("GAME TITLE {BRICK ENGINE} IN DEVELOPMENT", new Vector2i(1280, 720), 60);

            //using (Toolkit.Init()) new Engine("GAME TITLE {BRICK ENGINE} IN DEVELOPMENT", new Vector2i(1280, 720), 60);
        }
    }
}
