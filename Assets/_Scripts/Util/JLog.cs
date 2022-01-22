using UnityEngine;

namespace _Scripts.Util {
    public class JLog {
        public static void Log(params string[] strings) {
            var msg = "";
            foreach (var s in strings) {
                msg += s + " ";
            }

            Debug.Log(msg);
        }

        public static void Log(params object[] objects) {
            var msg = "";
            foreach (var o in objects) {
                msg += o + " ";
            }

            Debug.Log(msg);
        }
    }
}
