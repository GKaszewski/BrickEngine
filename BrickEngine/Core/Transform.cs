
using OpenTK;

namespace BrickEngine.Core
{
    public class Transform : Component
    {
        private Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector2 Scale { get; set; } = Vector2.One;

        public Matrix4 TransformationMatrix => Matrix4.CreateTranslation(new Vector3(_position.X, _position.Y, 0));

        public Transform() : this(Vector2.Zero) { }
        public Transform(Vector2 position) => _position = position;
        public Transform(float x, float y) => _position = new Vector2(x, y);

        public void Translate(Vector2 position) => _position += position;
        public void Translate(float x, float y) => _position += new Vector2(x, y);
    }
}
