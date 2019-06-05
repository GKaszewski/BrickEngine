using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using BrickEngine.Graphics;
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
        private Cube cubeMesh;

        float[] vertices =
        {
            //Position          Texture coordinates
            0.5f,  0.5f, 0.0f, 1f, 1.0f, // top right
            0.5f, -0.5f, 0.0f, 1f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f, 0.0f, 1f  // top left
        };

        int[] indices = {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3    // second triangle
        };

       

        protected override void Initialize()
        {
            shader = new Shader("Resources/Shaders/vertex.shader", "Resources/Shaders/fragment.shader");
            texture = new Texture("Resources/Graphics/test.png", true);
            var colorShader = new Shader("Resources/Shaders/colorVertex.shader", "Resources/Shaders/colorFragment.shader");

            var mesh = new TexturedSprite2D(vertices, indices, shader, texture);

            var col = Color.Green;

            float[] coloredVertices = {
                0.5f,  0.5f, 0.0f, col.R, col.G, col.B, col.A,  // top right
                0.5f, -0.5f, 0.0f, col.R, col.G, col.B, col.A, // bottom right
                -0.5f, -0.5f, 0.0f, col.R, col.G, col.B, col.A, // bottom left
                -0.5f,  0.5f, 0.0f,  col.R, col.G, col.B, col.A, // top left
            };

            int[] coloredIndices = {  // note that we start from 0!
                0, 1, 3,   // first triangle
                1, 2, 3    // second triangle
            };

            var coloredMesh = new ColoredSprite2D(coloredVertices, coloredIndices, Color.Blue, colorShader);
            sprite = new SpriteRenderer(coloredMesh);
       
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
