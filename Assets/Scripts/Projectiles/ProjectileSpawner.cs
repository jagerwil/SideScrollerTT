using Ducksten.Core.ObjectPooling;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Projectiles {
    public class ProjectileSpawner : MonoBehaviour {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Vector2 _projectileDirection = Vector2.down;
        [Space]
        [SerializeField] private Vector2 _spawnArea;
        [SerializeField] private float _projectilesPerSecond;

        private float _spawnInterval;
        private float _remainingTime;

        private void Awake() {
            _spawnInterval = 1f / _projectilesPerSecond;
        }

        private void Update() {
            _remainingTime -= Time.deltaTime;
            if (_remainingTime > 0f) {
                return;
            }

            SpawnProjectile();
            _remainingTime += _spawnInterval;
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

        private void OnDrawGizmos() {
            Gizmos.DrawWireCube(transform.position, _spawnArea);
        }
    }
}

