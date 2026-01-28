using ShootEmUp.Components;
using ShootEmUp.GameFlow;
using UnityEngine;

namespace ShootEmUp.Character
{
    
    public sealed class PlayerDeathHandler : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent hitPointsComponent; 
        [SerializeField] private GameFlowManager gameFlowManager;
 
        private void OnEnable() => hitPointsComponent.Died += OnDied;
        
        private void OnDisable() => hitPointsComponent.Died -= OnDied;
        
        private void OnDied(HitPointsComponent _) => gameFlowManager.FinishGame();
    }
}