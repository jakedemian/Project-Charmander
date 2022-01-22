using UnityEngine;

public class SpriteDirectionController : MonoBehaviour {
    private Transform _camera;
    void Start() {
        if (Camera.main != null) {
            _camera = Camera.main.transform;
        }
    }

    void Update() {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.position);
    }
}
