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
    public abstract class Mesh2D
    {
        protected int vao;
        protected int vbo;
        protected int ebo;
        protected int indices;

        public Mesh2D(float[] vertices, int[] indices)
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
        }

        ~Mesh2D()
        {
            //GL.DeleteBuffer(vbo);
            //GL.DeleteBuffer(ebo);
            //GL.DeleteBuffer(vao);
        }

        public abstract void Draw();
    }
}
