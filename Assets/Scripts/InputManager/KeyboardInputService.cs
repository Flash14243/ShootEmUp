using UnityEngine;

namespace ShootEmUp.InputManager
{
    public class KeyboardInputManager : MonoBehaviour, IInputManager
    {
        public float HorizontalDirection { get; private set; }
        public bool FirePressed { get; private set; }

        private void Update()
        {
            HorizontalDirection = Input.GetAxisRaw("Horizontal");
            FirePressed = Input.GetKeyDown(KeyCode.Space);
        }
    }
}


