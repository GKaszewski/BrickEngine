using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BrickEngine.Utility
{
    public class Mesh2D
    {
        private int vao;
        private int vbo;
        private int ebo;
        private int indices;

        public Mesh2D(float[] vertices, int[] indices, Shader shader)
        {
            vbo = GL.GenBuffer();
            ebo = GL.GenBuffer();
            vao = GL.GenVertexArray();
            this.indices = indices.Length;

            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, this.indices * sizeof(int), indices, BufferUsageHint.StaticDraw);

            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            int texCoordLocation = shader.GetAttribute("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

        }

        ~Mesh2D()
        {
            //GL.DeleteBuffer(vbo);
            //GL.DeleteBuffer(ebo);
            //GL.DeleteBuffer(vao);
        }

        public void Draw()
        {
           GL.BindVertexArray(vao);
           GL.DrawElements(PrimitiveType.Triangles, indices, DrawElementsType.UnsignedInt, 0);
        }
    }
}
