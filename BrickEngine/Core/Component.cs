using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickEngine.Core
{
    abstract class Component
    {
        protected GameObject gameObject;

        protected Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public abstract void Update();
    }
}
