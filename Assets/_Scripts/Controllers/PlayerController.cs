using _Scripts.Types;
using _Scripts.Util;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public float moveSpeed;

    private NullableVector3 currentMoveTarget;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        currentMoveTarget = new NullableVector3();
    }

    private void Update() {
        UpdateMoveTarget();
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget() {
        if (!currentMoveTarget.Exists()) {
            return;
        }

        var playerPos = transform.position;
        var playerPos2D = new Vector2(playerPos.x, playerPos.z);
        var targetPos = currentMoveTarget.Get();
        var targetPos2D = new Vector2(targetPos.x, targetPos.z);
        if (Vector2.Distance(playerPos2D, targetPos2D) < 0.5f) {
            currentMoveTarget.Clear();
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
            rb.velocity = Vector3.zero;
            return;
        }


        // bug to note, if you continuously path into a wall, your y value slowly raises
        var towardsTarget = targetPos - playerPos;
        var directionVector = new Vector3(towardsTarget.x, 0f, towardsTarget.z).normalized;
        rb.velocity = directionVector * moveSpeed;

        transform.LookAt(new Vector3(targetPos.x, 0, targetPos.z));
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }

    private void UpdateMoveTarget() {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity,
                    groundLayer)) {
                currentMoveTarget.Set(hit.point);

                if (currentMoveTarget.Exists()) {
                    JLog.Log(currentMoveTarget.Get());
                }
            }
        }
    }
}
