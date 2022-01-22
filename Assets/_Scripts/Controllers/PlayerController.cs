using _Scripts.Types;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    public LayerMask groundLayer;
    public float moveSpeed;
    private Animator _animator;

    private NullableVector3 _currentMoveTarget;
    private string _direction;
    private NavMeshAgent _navMeshAgent;
    private string _prevDirection;

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
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity,
                    groundLayer)) {
                _currentMoveTarget.Set(hit.point);
                _navMeshAgent.SetDestination(_currentMoveTarget.Get());
            }
        }
    }
}
