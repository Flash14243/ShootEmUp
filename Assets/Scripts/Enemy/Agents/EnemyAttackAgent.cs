using System;
using ShootEmUp.Components;
using UnityEngine;

namespace ShootEmUp.Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        
        public event Action<GameObject, Vector2, Vector2> Fired;
        
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField, Min(0.01f)] private float countdown=1f;

        private Transform _targetTransform;
        private IDamageable _targetHealth;
        private float _currentTime;

        private void OnEnable() => _currentTime = countdown;
        
        public void SetTarget(Transform targetTransform, IDamageable targetHealth)
        {
            _targetTransform = targetTransform;
            _targetHealth =  targetHealth;
        }
        
        private void FixedUpdate()
        {
            if (!moveAgent.IsReached) return;
            
            if (_targetHealth is not { IsAlive: true }) return;
            
            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime > 0) return;
            
            Fire();
            _currentTime = countdown;
        }

        private void Fire()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2) _targetTransform.transform.position - startPosition;
            var direction = vector.normalized;
            Fired?.Invoke(gameObject, startPosition, direction);
        }
    }
}