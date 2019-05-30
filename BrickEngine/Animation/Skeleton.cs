using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BrickEngine.Animation
{
    public struct Skeleton
    {
        public uint JointCount { get; set; }
        public Joint[] Joints { get; set; }
    }

    public struct SkeletonPose
    {
        public Skeleton Skeleton { get; set; }
        public JointPose LocalPose { get; set; }
        public Matrix4 GlobalPose { get; set; }
    }
}
