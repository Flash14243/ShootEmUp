using UnityEngine;

namespace ShootEmUp.Components
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [SerializeField] private bool isPlayer;
        public bool IsPlayer => isPlayer;
    }
}