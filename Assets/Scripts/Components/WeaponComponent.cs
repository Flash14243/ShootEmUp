using UnityEngine;

namespace ShootEmUp.Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        
        public Vector2 Position => firePoint.position;
        public Quaternion Rotation =>firePoint.rotation;

        private void OnValidate()
        {
            if(!firePoint) firePoint = transform;
        }
        
    }
}

