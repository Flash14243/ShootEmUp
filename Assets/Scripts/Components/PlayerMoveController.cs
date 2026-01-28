using ShootEmUp.InputManager;
using UnityEngine;

namespace ShootEmUp.Components
{
    [RequireComponent(typeof(MoveComponent))]
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour inputBehaviour;
        
        [SerializeField] private MoveComponent moveComponent;

        private IInputManager _inputManager;

        private void Awake()
        {
            if(!moveComponent) moveComponent = GetComponent<MoveComponent>();
            
            _inputManager = (IInputManager)inputBehaviour;
        }
        
        private void FixedUpdate()
        {
            var directional = new Vector2(_inputManager.HorizontalDirection, 0f);
            moveComponent.Move(directional);
        }
    }
}