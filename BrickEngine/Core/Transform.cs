using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace BrickEngine.Core
{
    class Transform : Component
    {
        public Vector2f position;
        public float rotation;
        public Vector2f scale;

        public Transform(GameObject gameObject) : base(gameObject)
        {
            position = gameObject.sprite.Position;
            rotation = gameObject.sprite.Rotation;
            scale = gameObject.sprite.Scale;
        }

        public override void Update()
        {
            gameObject.sprite.Position = position;
            gameObject.sprite.Rotation = rotation;
            gameObject.sprite.Scale = scale;
        }

    }
}
