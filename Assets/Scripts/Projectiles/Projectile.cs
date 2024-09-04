using Ducksten.Core.ObjectPooling;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Projectiles {
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : PoolObject {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        private Vector2 _moveVector;

        public void Init(Vector3 startPosition, Vector2 direction) {
            transform.position = startPosition;
            _moveVector = direction.normalized * _speed;
        }

        private void FixedUpdate() {
            _rigidbody.MovePosition(_rigidbody.position + _moveVector * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log($"Projectile trigger enter 2D! Object: {other.name}");
        }
    }
}

