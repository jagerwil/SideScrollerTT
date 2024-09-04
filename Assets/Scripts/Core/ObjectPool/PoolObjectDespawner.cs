using Ducksten.Core.ObjectPooling;
using UnityEngine;

namespace Ducksten.SideScrollerTT.Projectiles {
    [RequireComponent(typeof(Collider2D))]
    //Despawns pool objects when they leave collider
    public class PoolObjectDespawner : MonoBehaviour {
        private void OnTriggerExit2D(Collider2D other) {
            var obj = other.GetComponent<PoolObject>();
            if (obj) {
                obj.Despawn();
            }
        }
    }
}
