using _Scripts.Util;
using UnityEngine;

public class SpriteDirectionController : MonoBehaviour {
    private Transform _camera;

    private void Start() {
        _camera = Helpers.Camera.transform;
    }

    private void Update() {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.position);
    }
}
