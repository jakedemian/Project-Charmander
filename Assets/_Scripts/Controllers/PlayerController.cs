using _Scripts.Types;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public float moveSpeed;

    private NullableVector3 currentMoveTarget;
    private NavMeshAgent navMeshAgent;

    private void Start() {
        currentMoveTarget = new NullableVector3();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        UpdateMoveTarget();
    }

    private void UpdateMoveTarget() {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity,
                    groundLayer)) {
                currentMoveTarget.Set(hit.point);
                navMeshAgent.SetDestination(currentMoveTarget.Get());
            }
        }
    }
}
