using ShootEmUp.InputManager;
using UnityEngine;

namespace ShootEmUp.Character
{
    public sealed class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour inputBehaviour;
        [SerializeField] private CharacterShoot characterShot;
        
        private IInputManager _inputManager;
        
        private void Awake()=> _inputManager = inputBehaviour as IInputManager;
    
        private void Update()
        {
            if(_inputManager.FirePressed) characterShot.RequestFire();
        }
    }
}
