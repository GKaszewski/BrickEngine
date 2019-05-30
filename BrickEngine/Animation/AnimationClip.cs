using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickEngine.Animation
{
    public struct AnimationClip
    {
        public Skeleton Skeleton { get; set; }
        public float FramesPerSecond { get; set; }
        public uint FrameCount { get; set; }

        public AnimationSample[] Samples { get; }
        public bool IsLooping { get; set; }
    }
}
