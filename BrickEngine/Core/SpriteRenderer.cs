using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickEngine.Graphics;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BrickEngine.Core
{
    public class SpriteRenderer : Component
    {
        public Mesh2D Mesh { get; }
        public Color Color { get; } = Color.White;
        public Transform Transform { get; set; }
        
        public SpriteRenderer(Mesh2D mesh)
        {
            Transform = new Transform();
            Mesh = mesh;
        }

        public SpriteRenderer(Color color)
        {
            Color = color;
            Transform = new Transform();
        }

        public void Draw()
        {
           Mesh.Draw();
        }
    }
}
