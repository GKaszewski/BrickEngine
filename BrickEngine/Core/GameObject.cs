using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace BrickEngine.Core
{
    class GameObject
    {
        private Texture _texture;

        public List<Component> components = new List<Component>();
        public Sprite sprite;
        public Transform transform;

        private void InitializeComponents()
        {
            transform = new Transform(this);
            components.Add(transform);
        }

        public GameObject(Texture texture, Vector2f position)
        {
            _texture = texture;
            sprite = new Sprite(_texture);
            InitializeComponents();
            transform.position = position;
        }

        public GameObject(Texture texture)
        {
            _texture = texture;
            sprite = new Sprite(_texture);
            InitializeComponents();
        }

        public void UpdateComponents()
        {
            foreach (var component in components)
                component.Update();
        }

        public void Draw(RenderWindow window) => window.Draw(sprite);
    }   
}
