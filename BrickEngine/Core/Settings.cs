using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BrickEngine.Core
{
    public static class Settings
    {
        public static string Path { get; } = "Config/Settings.brickSettings";

        public static bool Wiremode { get; set; } = false;
        public static bool VSync { get; set; } = true;
        public static uint Framerate { get; set; } = 60;

        public static void LoadSettings()
        {
            if (File.Exists(Path))
            {
                using (var stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        Wiremode = binaryReader.ReadBoolean();
                        VSync = binaryReader.ReadBoolean();
                        Framerate = binaryReader.ReadUInt32();
                    }
                }
            }

            BaseEngine.Instance.VSync = VSync ? VSyncMode.On : VSyncMode.Off;
            RenderingSystem.Wiremode = Wiremode;
        }

        public static void SaveSettings()
        {
            Wiremode = RenderingSystem.Wiremode;

            if (!File.Exists(Path))
            {
                Directory.CreateDirectory("Config");
                using (var stream = new FileStream(Path, FileMode.Create, FileAccess.Write))
                {
                    using (var binaryWriter = new BinaryWriter(stream))
                    {
                        binaryWriter.Write(Wiremode);
                        binaryWriter.Write(VSync);
                        binaryWriter.Write(Framerate);
                    } 
                }
            }
            else
            {
                using (var stream = new FileStream(Path, FileMode.Create, FileAccess.Write))
                {
                    using (var binaryWriter = new BinaryWriter(stream))
                    {
                        binaryWriter.Write(Wiremode);
                        binaryWriter.Write(VSync);
                        binaryWriter.Write((int)Framerate);
                    }
                }
            }
        }
    }
}
