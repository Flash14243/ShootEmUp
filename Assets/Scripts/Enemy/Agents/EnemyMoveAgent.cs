using ShootEmUp.Components;
using UnityEngine;

namespace ShootEmUp.Enemy.Agents
{
    [RequireComponent(typeof(MoveComponent))]
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        [SerializeField] private MoveComponent moveComponent;

        [SerializeField, Min(0f)] private float stopDistance = 0.25f;

        public bool IsReached { get; private set; }

        private Vector2 _destination;
        private float _stopDistanceSqr;

        private void Awake()
        {
            if(!moveComponent) moveComponent = GetComponent<MoveComponent>();

            _stopDistanceSqr = stopDistance * stopDistance;
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        private void FixedUpdate()
        {
            if (IsReached) return;

            var toTarget = _destination - (Vector2)transform.position;
            
            if (toTarget.sqrMagnitude <= _stopDistanceSqr)
            {
                IsReached = true;
                return;
            }

            moveComponent.Move(toTarget.normalized);
        }
    }
}