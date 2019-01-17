using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace BrickEngine.Utility
{
    public class Mesh2D
    {
        private int _vboID;
        private int _iboID;
        private int _size;

        public Mesh2D(Vertex[] vertices, int[] indices)
        {
            _vboID = GL.GenBuffer();
            _iboID = GL.GenBuffer();
            _size = indices.Length;

            float[] data = Vertex.Process(vertices);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _iboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(int)), indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Draw()
        {
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vboID);
            GL.VertexAttribPointer(0,Vertex.SIZE, VertexAttribPointerType.Float, false, Vertex.SIZE * 4, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _iboID);
            GL.DrawElements(BeginMode.Triangles, _size, DrawElementsType.UnsignedInt, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DisableVertexAttribArray(0);
        }
    }
}
