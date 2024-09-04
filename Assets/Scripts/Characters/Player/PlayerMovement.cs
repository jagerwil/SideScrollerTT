using UnityEngine;

namespace Ducksten.SideScrollerTT.Characters.Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _horizontalMoveSpeed = 5f;
        [SerializeField] private float _verticalMoveSpeed = 1f;

        private Vector2 _moveVector;

        private void OnEnable() {
            _input.OnMoveVectorChanged += InputMoveVectorChanged;
        }

        private void OnDisable() {
            _input.OnMoveVectorChanged -= InputMoveVectorChanged;
        }

        private void FixedUpdate() {
            _rigidbody.MovePosition(_rigidbody.position + _moveVector * Time.fixedDeltaTime);
        }

        private void InputMoveVectorChanged(Vector2 inputVector) {
            _moveVector = new Vector2(inputVector.x * _horizontalMoveSpeed, inputVector.y * _verticalMoveSpeed);
        }
    }
}
