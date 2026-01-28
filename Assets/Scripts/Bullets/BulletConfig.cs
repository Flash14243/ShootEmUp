using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Bullets
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Bullets/New BulletConfig"
    )]
    public sealed class BulletConfig : ScriptableObject
    {
        private const int MinDamage = 1;
        private const int MaxDamage = 20;

        private const float MinSpeed = 0.1f;
        private const float MaxSpeed = 5;

        [SerializeField] private PhysicsLayer physicsLayer;

        [SerializeField] private Color color = Color.white;

        [SerializeField, Range(MinDamage, MaxDamage)]
        private int damage;

        [SerializeField, Range(MinSpeed, MaxSpeed)]
        private float speed;

        public PhysicsLayer PhysicsLayer => physicsLayer;
        public Color Color => color;
        public int Damage => damage;
        public float Speed => speed;
    }
}