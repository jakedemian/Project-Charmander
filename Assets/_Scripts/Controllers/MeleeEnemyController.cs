using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : MonoBehaviour {
    [SerializeField] private Transform target;
    private NavMeshAgent _navMeshAgent;

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        _navMeshAgent.SetDestination(target.position);
    }
}
