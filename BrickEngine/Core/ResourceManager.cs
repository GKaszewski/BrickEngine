using System.Collections.Generic;
using BrickEngine.Utility;

namespace BrickEngine.Core
{
    class ResourceManager
    {
        private static List<string> texturesLoaded = new List<string>();
        public static Dictionary<string, Texture> texturesResource = new Dictionary<string, Texture>();

        public static void LoadTexture(string path, string name)
        {
            var newTexture = new Texture(path);
            texturesResource.Add(name, newTexture);
            texturesLoaded.Add(name);
        }

        public static Texture GetTexture(string name) => texturesResource[name];

        public static void UnloadTexture(string name) => texturesResource.Remove(name);

        public static void UnloadTextures()
        {
            foreach (var name in texturesLoaded)
                texturesResource.Remove(name);
        }

    }
}
