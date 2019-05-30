using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BrickEngine.Core
{
    public class RenderingSystem
    {
        public static bool Wiremode { get; set; } = false;

        public static void Initialize() => Initialize(new Vector3(1f,1f,1f));

        public static void Initialize(Vector3 color)
        {
            GL.ClearColor(color.X, color.Y, color.Z, 0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.FramebufferSrgb);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public static void ClearScreen() => GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        public static void SetClearColor(Vector4 color) => GL.ClearColor(color.X / 255f, color.Y / 255f, color.Z / 255f, color.W);
        public static void SetClearColor(Vector3 color, float alpha = 0f) => GL.ClearColor(color.X / 255f, color.Y / 255f, color.Z / 255f, alpha);
        public static void SetClearColor(float red, float green, float blue, float alpha = 0f) => GL.ClearColor(red / 255f, green / 255f, blue / 255f, alpha);
        public static void SetClearColor(Color color) => GL.ClearColor(color);

        public static void RunConfiguration()
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, Wiremode ? PolygonMode.Line : PolygonMode.Fill);
        }

        public static void Update()
        {

        }
    }
}
