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
        private readonly Clock _clock = new Clock();
        private GameObject test;
        private Vector2f moving;

        private float rotate = 1f;
        private float speed = 10;

        public Engine(string title, Vector2u size, uint framerate)
        {
            var settings = new ContextSettings();
            settings.AntialiasingLevel = 8;
            _window = new RenderWindow(new VideoMode(size.X, size.Y), title, Styles.Default, settings);
            _window.SetFramerateLimit(framerate);
        }

        private void LoadResources()
        {
            ResourceManager.LoadTexture("Graphics/test.png", "test");
            test = new GameObject(ResourceManager.GetTexture("test"), new Vector2f(560, 120));
        }

        private void HandleEvents()
        {
            _window.Closed += Close;
            _window.DispatchEvents();
        }

        private void HandleInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                moving.X++;
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                moving.X--;
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.Space))
                moving.Y--;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                moving.Y++;
        }

        private void Close(object sender, EventArgs e)
        {
            ResourceManager.UnloadTextures();
            _window.Close();
        }

        private void Update(float deltaTime)
        {
            //rotate++;
            test.transform.position = moving * speed;
            test.transform.rotation = rotate;
            test.UpdateComponents();
        }

        private void Render()
        {
            _window.Clear();
            test.Draw(_window);
            _window.Display();
        }

        public void Run()
        {
            LoadResources();

            while (_window.IsOpen)
            {
                HandleEvents();
                HandleInput();
                
                var time = _clock.Restart();
                float deltaTime = time.AsMilliseconds();

                Update(deltaTime);
                Render();
            }
        }
    }
}
