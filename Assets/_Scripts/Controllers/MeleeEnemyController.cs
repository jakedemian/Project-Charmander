using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : MonoBehaviour {
    [SerializeField] private Transform target;
    private NavMeshAgent navMeshAgent;

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        navMeshAgent.SetDestination(target.position);
    }
}
