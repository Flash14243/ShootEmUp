using System.Collections;
using System.Collections.Generic;
using ShootEmUp.Bullets;
using ShootEmUp.Common;
using ShootEmUp.Components;
using ShootEmUp.Enemy.Agents;
using UnityEngine;

namespace ShootEmUp.Enemy
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private BulletSystem bulletSystem;
        
        private readonly HashSet<GameObject> _activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                GameObject enemy = enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().Died += OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().Fired += OnFire;
                    }    
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void OnDestroyed(HitPointsComponent enemyHitPoints)
        {
            GameObject enemy = enemyHitPoints.gameObject;
            if (_activeEnemies.Remove(enemy))
            {
                enemyHitPoints.Died -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().Fired -= OnFire;

                enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int) PhysicsLayer.EnemyBullet,
                Color = Color.red,
                Damage = 1,
                Position = position,
                Velocity = direction * 2.0f
            });
        }
    }
}