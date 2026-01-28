using UnityEngine;

namespace ShootEmUp.Components
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;
        public void Move(Vector2 direction)
        {
            var deltaTime = Time.fixedDeltaTime;
            var delta = direction * (speed * deltaTime);
            rigidbody2D.MovePosition(rigidbody2D.position + delta);
        }
    }
}
