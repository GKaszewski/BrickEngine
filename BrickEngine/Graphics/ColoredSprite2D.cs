using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickEngine.Utility;
using OpenTK.Graphics.OpenGL;

namespace BrickEngine.Graphics
{
    public class ColoredSprite2D : Mesh2D
    {
        public Shader Shader { get; }
        public Color Color { get; }

        private float[] colorData;

        public ColoredSprite2D(float[] vertices, int[] indices, Color color, Shader shader) : base(vertices, indices)
        {
            Color = color;
            Shader = shader;

            colorData = new float[]
            {
                Color.R, Color.G, Color.B, 1
            };

            Console.WriteLine($"R:{Color.R} G:{Color.G} B:{Color.B} A:{Color.A}");

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 7 * sizeof(float), 0);
            int colorAttribLocation = Shader.GetAttribute("color");
            GL.EnableVertexAttribArray(colorAttribLocation);
            GL.VertexAttribPointer(colorAttribLocation, 4, VertexAttribPointerType.Float, false, 7 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
        }

        public override void Draw()
        {
            Shader.Start();
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, indices, DrawElementsType.UnsignedInt, 0);
            Shader.Stop();
        }
    }
}
