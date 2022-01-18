using System.Data;
using UnityEngine;

namespace _Scripts.Types {
    public class NullableVector3 {
        private bool hasValue;
        private Vector3 vector = Vector3.zero;

        public NullableVector3(float x, float y, float z) {
            Set(x, y, z);
        }

        public NullableVector3(Vector3 v) {
            Set(v);
        }

        public NullableVector3() {
            Clear();
        }

        public void Set(float x, float y, float z) {
            vector = new Vector3(x, y, z);
            hasValue = true;
        }

        public void Set(Vector3 v) {
            vector = v;
            hasValue = true;
        }

        public void Clear() {
            vector = Vector3.zero;
            hasValue = false;
        }

        public Vector3 Get() {
            if (!hasValue) {
                throw new DataException("Cannot return Vector3, it has no value.");
            }

            return vector;
        }

        public bool Exists() {
            return hasValue;
        }
    }
}
