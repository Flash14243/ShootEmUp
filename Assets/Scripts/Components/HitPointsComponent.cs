using System;
using UnityEngine;

namespace ShootEmUp.Components
{
    public sealed class HitPointsComponent : MonoBehaviour,IDamageable
    {
        public event Action<HitPointsComponent> Died;
        
        [SerializeField, Min(1)] private int maxHitPoints=1;
        
        private int _hitPoints;
        
        public bool IsAlive => _hitPoints > 0;
        
        private void Awake()=>_hitPoints = maxHitPoints;
        
        public void ResetHp()=> _hitPoints = maxHitPoints;
        
        public void TakeDamage(int damage)
        {
            if(!IsAlive) return;
            if(damage<=0) return;
            
            _hitPoints -= damage;
            if (_hitPoints > 0) return;
            
            _hitPoints = 0;
            Died?.Invoke(this);
        }
    }
}


public interface IDamageable
{
    public bool IsAlive { get; }

    public void TakeDamage(int damage);
}