using UnityEngine;
using UnityEngine.AI;

public class AgentCubeMove : MonoBehaviour {
    public Transform destination;

    private NavMeshAgent _navMeshAgent;
    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null) {
            Debug.LogError("The nav mesh agent component ain't there, chief...");
        } else {
            SetDestination();
        }
    }

    void SetDestination() {
        if (destination != null) {
            Vector3 targetVector = destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

}
