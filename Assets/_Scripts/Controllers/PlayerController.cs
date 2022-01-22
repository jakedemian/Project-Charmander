using _Scripts.Types;
using _Scripts.Util;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;

    private NullableVector3 _currentMoveTarget;
    private NavMeshAgent _navMeshAgent;

    private void Start() {
        _currentMoveTarget = new NullableVector3();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        UpdateMoveTarget();
    }

    private void UpdateMoveTarget() {
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            if (Physics.Raycast(Helpers.Camera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity,
                    groundLayer)) {
                _currentMoveTarget.Set(hit.point);
                _navMeshAgent.SetDestination(_currentMoveTarget.Get());
            }
        }
    }
}
