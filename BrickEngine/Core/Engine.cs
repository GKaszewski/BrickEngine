using System;
using BrickEngine.Utility;
using OpenTK;
using OpenTK.Input;

namespace BrickEngine.Core
{
    class Engine : BaseEngine
    {
        private Mesh2D _mesh;
        private Shader _shader;
        private Transform _transform;

        public Engine(string title, Vector2i size, uint framerate) : base(title, size, framerate){}

        protected override void Initialize()
        {
            _transform = new Transform();
            _shader = new Shader("Resources/Shaders/vertex.shader", "Resources/Shaders/fragment.shader");
            _shader.AddUniform("transformationMatrix");

            Vertex[] verticies = new Vertex[]
            {
                new Vertex(-0.5f,0.5f),
                new Vertex(-0.5f,-0.5f),
                new Vertex(0.5f,-0.5f),
                new Vertex(0.5f,0.5f),
            };

            int[] indices = new[]
            {
                0,1,3,
                3,1,2
            };

           _mesh = new Mesh2D(verticies, indices);
        }

        protected override void Update()
        {
            if(Input.GetKey(Key.W)) _transform.Translate(0, 0.1f);
            if(Input.GetKey(Key.S)) _transform.Translate(0, -0.1f);
            if(Input.GetKey(Key.A)) _transform.Translate(-0.1f, 0f);
            if(Input.GetKey(Key.D)) _transform.Translate(0.1f, 0f);
        }

        protected override void Render()
        {
            _shader.Start();
            _shader.LoadMatrix("transformationMatrix", _transform.TransformationMatrix);
            _mesh.Draw();
            _shader.Stop();
        }

        protected override void OnClose()
        {
            
        }
    }
}
