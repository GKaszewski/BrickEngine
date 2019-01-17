using OpenTK;

namespace BrickEngine.Utility
{
    public struct Vertex
    {
        private Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public const int SIZE = 2;

        public Vertex(Vector2 position) => _position = position;
        public Vertex(float x, float y) => _position = new Vector2(x,y);

        public static float[] Process(Vertex[] vertices)
        {
            var count = 0;
            var data = new float[vertices.Length * SIZE];

            for (var i = 0; i < vertices.Length; i++)
            {
                data[count] = vertices[i].Position.X;
                data[count+1] = vertices[i].Position.Y;

                count += 2;
            }

            return data;
        }
    }
}
