using System.Collections.Generic;
using System.Linq;
using _Scripts.Util;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour {
    private Animator _animator;
    private string _direction;
    private NavMeshAgent _navMeshAgent;
    private string _prevDirection;

    private void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();

        _direction = "idle";
        _prevDirection = "idle";
    }

    private void Update() {
        if (_navMeshAgent.velocity == Vector3.zero) {
            _direction = "idle";
        } else {
            var vel = _navMeshAgent.velocity;
            SetCurrentDirection(vel.normalized);
        }

        UpdateAnimator();
    }

    private void UpdateAnimator() {
        JLog.Log(_direction, Animator.StringToHash(_direction));
        _animator.SetInteger("Direction", Animator.StringToHash(_direction));
    }

    private void SetCurrentDirection(Vector3 normalizedVelocity) {
        var directions = new Dictionary<string, float> {
            { "left", 0 },
            { "right", 0 },
            { "forward", 0 },
            { "backward", 0 }
        };

        var modifiedDirections = new Dictionary<string, float>();
        foreach (var dir in directions) {
            var camDir = GetNormalizedCameraDirection(dir.Key);
            modifiedDirections[dir.Key] = Vector3.Dot(normalizedVelocity, camDir);
        }

        //JLog.Log(modifiedDirections["left"], modifiedDirections["right"]);

        var keyOfMaxValue = modifiedDirections.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
        _direction = keyOfMaxValue;
    }

    private Vector3 GetNormalizedCameraDirection(string dir) {
        var camTransform = Camera.main.transform;

        if (dir == "left") {
            return -camTransform.right.normalized;
        }

        if (dir == "right") {
            return camTransform.right.normalized;
        }

        if (dir == "forward") {
            return new Vector3(camTransform.forward.x, 0, camTransform.forward.z).normalized;
        }

        if (dir == "backward") {
            return new Vector3(-camTransform.forward.x, 0, -camTransform.forward.z).normalized;
        }

        return Vector3.zero;
    }
}
