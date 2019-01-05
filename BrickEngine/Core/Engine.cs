using System;
using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace BrickEngine.Core
{
    class Engine
    {
        private RenderWindow _window;
        public Engine(string title, Vector2u size, uint framerate, bool fullscreen)
        {
            var settings = new ContextSettings();

            if (fullscreen)
                settings.AntialiasingLevel = 8;

            _window.SetTitle(title);
            _window.Size = size;
            _window.SetFramerateLimit(framerate);
        }
    }
}
