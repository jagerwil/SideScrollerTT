using Ducksten.Core;
using Ducksten.Core.ObjectPooling;
using Ducksten.SideScrollerTT.Events;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Projectiles {
    public class ProjectileSpawner : MonoBehaviour {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Vector2 _projectileDirection = Vector2.down;
        [Space]
        [SerializeField] private Vector2 _spawnArea;
        [SerializeField] private float _projectilesPerSecond;

        private bool _isActive = true; //Можно использовать встроенный enabled, но про него легче забыть, т.к. в коде не будет явно видно что он Update отключает
        private SimpleTimer _timer;

        private void Awake() {
            var spawnInterval = 1f / _projectilesPerSecond;
            _timer = new SimpleTimer(spawnInterval, SpawnProjectile);
        }

        private void OnEnable() {
            GameEvents.onGameOver.Subscribe(DisableSpawn);
        }

        private void OnDisable() {
            GameEvents.onGameOver.Unsubscribe(DisableSpawn);
        }

        private void Update() {
            if (!_isActive)
                return;
            
            _timer.Tick(Time.deltaTime);
        }

        private void SpawnProjectile() {
            var projectile = PoolObjectFactory.Instance.SpawnObject(_prefab);

            var startPosition = GetRandomPosition();
            projectile.Init(startPosition, _projectileDirection);
        }

        private Vector2 GetRandomPosition() {
            var randomPos = transform.position;
            randomPos.x += Random.Range(-0.5f * _spawnArea.x, 0.5f * _spawnArea.x);
            randomPos.y += Random.Range(-0.5f * _spawnArea.y, 0.5f * _spawnArea.y);
            return randomPos;
        }

        private void DisableSpawn() {
            _isActive = false;
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireCube(transform.position, _spawnArea);
        }
    }
}

