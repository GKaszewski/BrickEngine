using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BrickEngine.Core
{
    public class Engine : BaseEngine
    {
        public Engine(string title, Vector2i size) : base(title, size){}

        private SpriteRenderer sprite;
        private Shader shader;
        private Texture texture;

        float[] vertices = {
            0.5f,  0.5f, 0.0f,  // top right
            0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f   // top left
        };

        int[] indices = {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };


        protected override void Initialize()
        {
            shader = new Shader("Resources/Shaders/vertex.shader", "Resources/Shaders/fragment.shader");
            texture = new Texture("Resources/Graphics/test1.png");
            var mesh = new Mesh2D(vertices, indices);
            sprite = new SpriteRenderer(texture, shader, mesh);
        }

        protected override void Update()
        {
 
        }

        protected override void Render()
        {
            sprite.Draw();
        }

        protected override void OnClose()
        {
        }
    }
}
