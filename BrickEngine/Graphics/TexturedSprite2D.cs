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
    public class TexturedSprite2D : Mesh2D
    {
        public Texture Texture { get; set; }
        public Shader Shader { get; set; }

        public TexturedSprite2D(float[] vertices, int[] indices) : base(vertices, indices)
        {
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            int texCoordLocation = Shader.GetAttribute("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
        }

        public TexturedSprite2D(float[] vertices, int[] indices, Shader shader, Texture texture) : base(vertices, indices)
        {
            Shader = shader;
            Texture = texture;

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            int texCoordLocation = Shader.GetAttribute("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);
        }

        public override void Draw()
        {
            Shader.Start();
            GL.BindTexture(TextureTarget.Texture2D, Texture.ID);
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, indices, DrawElementsType.UnsignedInt, 0);
            Shader.Stop();
        }
    }
}
