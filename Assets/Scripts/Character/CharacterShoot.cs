using ShootEmUp.Bullets;
using ShootEmUp.Common;
using ShootEmUp.Components;
using UnityEngine;

namespace ShootEmUp.Character
{
    public class CharacterShoot : MonoBehaviour
    {
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private WeaponComponent weapon;
        
        public PhysicsLayer PhysicsLayer => bulletConfig.PhysicsLayer;
        public int Damage => bulletConfig.Damage;
        public float Speed => bulletConfig.Speed;
        public Color BulletColor => bulletConfig.Color;
     
        private bool _fireRequired;

        private void Awake()
        {
            if (!weapon) weapon = GetComponent<WeaponComponent>();
        }
        
        private void Update()
        {
            if (!_fireRequired) return;
            _fireRequired = false;
            Fire();
        }
        
        public void RequestFire()=> _fireRequired = true;

        private void Fire()
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int)PhysicsLayer,
                Color = BulletColor,
                Damage = Damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * Speed
            });
        }
    }
}