using UnityEngine;

namespace ShootEmUp.GameFlow
{
    public sealed class GameFlowManager : MonoBehaviour
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}