using System.Data;
using UnityEngine;

namespace _Scripts.Types {
    public class NullableVector3 {
        private bool _hasValue;
        private Vector3 _vector = Vector3.zero;

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
            _vector = new Vector3(x, y, z);
            _hasValue = true;
        }

        public void Set(Vector3 v) {
            _vector = v;
            _hasValue = true;
        }

        public void Clear() {
            _vector = Vector3.zero;
            _hasValue = false;
        }

        public Vector3 Get() {
            if (!_hasValue) {
                throw new DataException("Cannot return Vector3, it has no value.");
            }

            return _vector;
        }

        public bool Exists() {
            return _hasValue;
        }
    }
}