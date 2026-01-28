using System.Collections.Generic;
using ShootEmUp.Components;
using ShootEmUp.Enemy.Agents;
using UnityEngine;

namespace ShootEmUp.Enemy
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions enemyPositions;

        [SerializeField]
        private HitPointsComponent character;

        [SerializeField]
        private Transform worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private GameObject prefab;

        private readonly Queue<GameObject> _enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < 7; i++)
            {
                GameObject enemy = Instantiate(prefab, container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
                return null;
            

            enemy.transform.SetParent(worldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(character.transform,character);
            
            enemy.GetComponent<HitPointsComponent>().ResetHp();
            
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.container);
            _enemyPool.Enqueue(enemy);
        }
    }
}