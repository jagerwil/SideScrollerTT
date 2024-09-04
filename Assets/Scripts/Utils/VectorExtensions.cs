using UnityEngine;

namespace Ducksten {
    public static class VectorExtensions {
        public static bool IsApproximate(this Vector2 v1, Vector2 v2) {
            return Mathf.Approximately(v1.x, v2.x) && Mathf.Approximately(v1.y, v2.y);
        }
    }
}
