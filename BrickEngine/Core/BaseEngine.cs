using System;
using System.Drawing;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace BrickEngine.Core
{
    public abstract class BaseEngine : GameWindow
    {
        private static BaseEngine _instance;
        public static BaseEngine Instance => _instance;

        protected BaseEngine(string title, Vector2i size) : base(size.X, size.Y, GraphicsMode.Default, title)
        {
            if (Instance == null)
                _instance = this;

            Settings.LoadSettings();
            Run(Settings.Framerate);
        }

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = true;
            Initialize();
            RenderingSystem.Initialize();
            RenderingSystem.SetClearColor(Color.Black);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnClosed(EventArgs e)
        {
            OnClose();
            Dispose();
            Settings.SaveSettings();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            RenderingSystem.Update();
            Input.Update();
            Update();

            if (Input.GetKeyDown(Key.F10))
                RenderingSystem.Wiremode = !RenderingSystem.Wiremode;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            VSync = Settings.VSync ? VSyncMode.On : VSyncMode.Off;
            Title = $"BrickEngine VSync: ({VSync.ToString()}) FPS: ({1f / e.Time:0}) Limit FPS: ({Settings.Framerate}) - UNLICENSED VERSION";

            var projection = Matrix4.CreateOrthographicOffCenter(0, Width, Height, 0, 0, 1);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            RenderingSystem.ClearScreen();
            RenderingSystem.RunConfiguration();
            Render();
            SwapBuffers();
        }

        protected abstract void Initialize();

        protected abstract void Update();

        protected abstract void Render();

        protected abstract void OnClose();
    }
}
