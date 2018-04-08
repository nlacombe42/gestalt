using UnityEngine;

namespace code.util
{
    public class Position3D
    {
        public Position3D() : this(0, 0, 0)
        {
        }

        public Position3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int x { get; set; }

        public int y { get; set; }

        public int z { get; set; }

        public static Vector3 operator *(Position3D position3D, Vector3 vector3)
        {
            return new Vector3(position3D.x * vector3.x, position3D.y * vector3.y, position3D.z * vector3.z);
        }

        public static Vector3 operator *(Position3D position1, Position3D position2)
        {
            return new Vector3(position1.x * position2.x, position1.y * position2.y, position1.z * position2.z);
        }
    }
}