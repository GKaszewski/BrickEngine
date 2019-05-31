using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BrickEngine.Core
{
    public class SpriteRenderer : Component
    {
        public Texture Texture { get; }
        public Shader Shader { get; }
        public Mesh2D Mesh { get; }
        public Color Color { get; } = Color.White;
        public Transform Transform { get; set; }
        
        public SpriteRenderer(Texture texture, Shader shader, Mesh2D mesh)
        {
            Transform = new Transform();
            Texture = texture;
            Shader = shader;
            Mesh = mesh;
        }

        public SpriteRenderer(Texture texture, Color color)
        {
            Texture = texture;
            Color = color;
            Transform = new Transform();
        }

        public void Draw()
        {
            Shader.Start();
            GL.BindTexture(TextureTarget.Texture2D, Texture.ID);
            Mesh.Draw();
            Shader.Stop();
        }
    }
}
