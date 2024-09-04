using System.Collections.Generic;
using UnityEngine;

namespace Ducksten.Core.ObjectPooling {
    public class PoolObjectFactory : Singleton<PoolObjectFactory> {
        private Dictionary<string, ObjectPool> _pools = new();
        private Transform _objectsRoot;

        protected override bool Awake() {
            if (!base.Awake())
                return false;

            _objectsRoot = transform;
            return true;
        }

        public T SpawnObject<T>(T prefab, Transform parent = null) where T : PoolObject {
            var pool = GetPool(prefab);
            return (T)pool?.SpawnObject(parent);
        }

        public void DespawnAll(PoolObject prefab) {
            var pool = GetPool(prefab);
            pool?.DespawnAll();
        }

        private ObjectPool GetPool(PoolObject prefab) {
            var id = prefab.Guid;
            if (_pools.TryGetValue(id, out var pool)) {
                return pool;
            }

            pool = new ObjectPool(prefab, _objectsRoot);
            _pools.Add(prefab.Guid, pool);
            return pool;
        }
    }
}
