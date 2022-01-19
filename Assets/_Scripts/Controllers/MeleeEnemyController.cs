using System;
using System.Threading.Tasks;
using _Scripts.Util;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : MonoBehaviour {
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform target;

    // TODO perhaps calculate this as radius of my own hitbox + whatever this value is?
    [SerializeField] private float meleeRange;
    [SerializeField] private float meleeCooldown;
    [SerializeField] private float swingDelay;

    public float meleeDamage;
    private float _calculatedMeleeRange;

    private bool _isMeleeing;
    // TODO swingSize variable(s) to adjust the width of the range

    private float _meleeTimer;

    private NavMeshAgent _navMeshAgent;

    private void Start() {
        target = GameObject.FindWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _calculatedMeleeRange = GetComponent<CapsuleCollider>().radius + meleeRange;
    }

    private void Update() {
        var targetPos = target.position;

        _navMeshAgent.SetDestination(targetPos);

        var distanceToPlayer = Vector3.Distance(transform.position, targetPos);
        if (distanceToPlayer < _calculatedMeleeRange && !_isMeleeing && !OnCooldown()) {
            Melee();
            _meleeTimer = meleeCooldown;
        }

        if (_meleeTimer > 0f) {
            _meleeTimer -= Time.deltaTime;
        }
    }

    private async void Melee() {
        _isMeleeing = true;
        _navMeshAgent.isStopped = true;
        Debug.Log("waiting for swing timer...doing melee animation here");
        await Task.Delay(TimeSpan.FromSeconds(swingDelay));

        var pos = transform.position;
        var colliders = Physics.OverlapCapsule(pos + new Vector3(0, 2, 0),
            pos - new Vector3(0, 2, 0), _calculatedMeleeRange, playerLayer);

        if (colliders.Length > 0) {
            // TODO still need to make sure the player was within the valid "swingSize" area.
            // TODO     otherwise player will still be hit even if behind the enemy

            var player = colliders[0].gameObject;
            // TODO player<HealthComponent>().DealDamage(meleeDamage);
        }

        JLog.Log(meleeDamage, " damage dealt now!  Did it hit??", colliders.Length);
        _navMeshAgent.isStopped = false;
        _isMeleeing = false;
    }

    private bool OnCooldown() {
        return _meleeTimer > 0f;
    }
}
