using System.Collections;
using UnityEngine;

namespace Ducksten {
    public abstract class UiBehaviour : MonoBehaviour {
        protected RectTransform rectTransform;

        protected virtual void Awake() {
            rectTransform = transform as RectTransform;
        }

        protected virtual void Start() {
            StartCoroutine(LateStartCoro());
        }
        
        protected virtual void LateStart() { }

        IEnumerator LateStartCoro() {
            yield return null;
            LateStart();
        }
    }
}
