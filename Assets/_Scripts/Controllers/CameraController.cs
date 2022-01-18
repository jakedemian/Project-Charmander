using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float zoomLevel = 1;
    [Range(0.1f, 1f)] public float mouseSensitivity;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 offset;

    private void Awake() {
        offset = transform.position - target.position;
    }

    private void LateUpdate() {
        var targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        var mouseWheel = Input.mouseScrollDelta;
        zoomLevel = Mathf.Clamp(zoomLevel - mouseWheel.y * mouseSensitivity, 3, 7);
        Camera.main.orthographicSize = zoomLevel;
    }
}
