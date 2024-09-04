using System;
using UnityEngine;

namespace Ducksten.SideScrollerTT {
    [RequireComponent(typeof(Collider2D))]
    public class HitDetector : MonoBehaviour, IDamageable {
        public event Action onHitDetected;

        public void TakeDamage() {
            onHitDetected?.Invoke();
        }
    }
}
