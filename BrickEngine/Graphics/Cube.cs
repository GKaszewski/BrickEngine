using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace BrickEngine.Graphics
{
    public class Cube : Mesh3D
    {
        public Cube()
        {
            VertexCount = 8;
            IndiceCount = 36;
            ColorDataCount = 8;
        }

        public override float[] GetVerticies()
        {
            return new float[] {
                -0.5f, -0.5f,  -0.5f,
                0.5f, -0.5f,  -0.5f,
                0.5f, 0.5f,  -0.5f,
                -0.5f, 0.5f,  -0.5f,
                -0.5f, -0.5f,  0.5f,
                0.5f, -0.5f,  0.5f,
                0.5f, 0.5f,  0.5f,
                -0.5f, 0.5f,  0.5f,
            };
        }

        public override int[] GetIndices(int offset = 0)
        {
            var inds =  new int[]
            {
                //left
                0, 2, 1,
                0, 3, 2,
                //back
                1, 2, 6,
                6, 5, 1,
                //right
                4, 5, 6,
                6, 7, 4,
                //top
                2, 3, 6,
                6, 3, 7,
                //front
                0, 7, 3,
                0, 4, 7,
                //bottom
                0, 1, 5,
                0, 5, 4
            };

            if (offset != 0)
            {
                for (int i = 0; i < inds.Length; i++)
                {
                    inds[i] += offset;
                }
            }

            return inds;
        }

        public override float[] GetColorData()
        {
            return new float[] {
                1f, 0f, 0f,
                0f, 0f, 1f,
                0f, 1f, 0f,
                1f, 0f, 0f,
                0f, 0f, 1f,
                0f, 1f, 0f,
                1f, 0f, 0f,
                0f, 0f, 1f 
            };
        }

        public override void CalculateModelMatrix()
        {
            ModelMatrix = Matrix4.CreateScale(Scale) * 
                          Matrix4.CreateRotationX(Rotation.X) *
                          Matrix4.CreateRotationY(Rotation.Y) * 
                          Matrix4.CreateRotationZ(Rotation.Z);
        }

        public override void Draw()
        {
            
        }
    }
}
