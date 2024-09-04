using UnityEngine;

namespace Ducksten.Core.ObjectPooling {
    public class PoolObject : MonoBehaviour {
        private bool _isSpawned;
        private ObjectPool _pool;

        public string Guid => System.Guid.NewGuid().ToString();

        public void Spawn(ObjectPool pool) {
            if (_isSpawned)
                return;

            _pool = pool;
            gameObject.SetActive(true);
            _isSpawned = true;
        }

        public void Despawn() {
            if (!_isSpawned)
                return;

            gameObject.SetActive(false);
            _pool.ReturnToPool(this);
            _isSpawned = false;
        }
    }
}