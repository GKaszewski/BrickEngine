using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BrickEngine.Animation
{
    public struct Joint
    {
        public string Name { get; set; }
        public ushort Parent { get; set; }
        public Matrix4x3 InverseBindPose { get; set; }
    }

    public struct JointPose
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }
    }
}
