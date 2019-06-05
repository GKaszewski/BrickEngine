using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BrickEngine.Utility
{
    public abstract class Mesh3D
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Vector3 Rotation { get; set; } = Vector3.Zero;
        public Vector3 Scale { get; set; } = Vector3.Zero;

        public int VertexCount { get; protected set; }
        public int IndiceCount { get; protected set; }
        public int ColorDataCount { get; protected set; }
        public Matrix4 ModelMatrix = Matrix4.Identity;
        public Matrix4 ViewProjectionMatrix = Matrix4.Identity;
        public Matrix4 ModelViewProjectionMatrix = Matrix4.Identity;

        protected int vao;
        protected int vbo;
        protected int ebo;

        public abstract float[] GetVerticies();
        public abstract int[] GetIndices(int offset = 0);
        public abstract float[] GetColorData();
        public abstract void CalculateModelMatrix();
        public abstract void Draw();

    }
}
