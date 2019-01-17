using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace BrickEngine.Core
{
    public class RenderingSystem
    {

        public static void Initialize() => Initialize(new Vector3(1f,1f,1f));

        public static void Initialize(Vector3 color)
        {
            GL.ClearColor(color.X, color.Y, color.Z, 0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.FramebufferSrgb);
        }

        public static void ClearScreen() => GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        public static void SetClearColor(Vector4 color) => GL.ClearColor(color.X / 255f, color.Y / 255f, color.Z / 255f, color.W);
        public static void SetClearColor(Vector3 color, float alpha = 0f) => GL.ClearColor(color.X / 255f, color.Y / 255f, color.Z / 255f, alpha);
        public static void SetClearColor(float red, float green, float blue, float alpha = 0f) => GL.ClearColor(red / 255f, green / 255f, blue / 255f, alpha);
    }
}
