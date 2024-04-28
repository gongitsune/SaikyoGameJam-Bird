using UnityEngine;

namespace Projects.Scripts.Common
{
    public static class VectorExt
    {
        private static int Floor(this float value)
        {
            if (value < 0)
                return -(int)-value;
            return (int)value;
        }

        public static Vector3 Floor(this Vector3 vector)
        {
            return new Vector3(Floor(vector.x), Floor(vector.y), Floor(vector.z));
        }
    }
}