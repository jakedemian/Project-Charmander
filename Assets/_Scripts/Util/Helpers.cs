using UnityEngine;

namespace _Scripts.Util {
    public static class Helpers {
        public static float Vector3Distance2D(Vector3 a, Vector3 b) {
            return Vector2.Distance(new Vector2(a.x, a.z), new Vector2(b.x, b.z));
        }
    }
}
