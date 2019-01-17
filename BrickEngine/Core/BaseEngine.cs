using System;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Graphics;

namespace BrickEngine.Core
{
    public abstract class BaseEngine : GameWindow
    {
        private static BaseEngine _instance;
        public static BaseEngine Instance => _instance;

        protected BaseEngine(string title, Vector2i size, uint framerate) : base(size.X, size.Y, GraphicsMode.Default, title)
        {
            if (Instance == null)
                _instance = this;

            Run(framerate);
        }

        protected override void OnLoad(EventArgs e)
        {
            Initialize();
            RenderingSystem.Initialize();
        }

        protected override void OnClosed(EventArgs e)
        {
            OnClose();
            Dispose();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Input.Update();
            Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            RenderingSystem.ClearScreen();
            Render();
            SwapBuffers();
        }

        protected abstract void Initialize();

        protected abstract void Update();

        protected abstract void Render();

        protected abstract void OnClose();
    }
}
