using UnityEngine;

namespace Projects.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed, rotatePower, verticalPower;

        private PlayerInput _input;
        private Rigidbody _rigid;
        private Vector2 _rotation;

        private void Start()
        {
            _input = new PlayerInput();
            TryGetComponent(out _rigid);
        }

        private void Update()
        {
            _input.CheckInput();
        }

        private void FixedUpdate()
        {
            if (_input.LeftWing && _input.RightWing)
                _rotation.x -= verticalPower * Time.fixedDeltaTime;
            else if (!_input.LeftWing && !_input.RightWing)
                _rotation.x += verticalPower * Time.fixedDeltaTime;

            if (_input.LeftWing)
                _rotation.y -= rotatePower * Time.fixedDeltaTime;
            if (_input.RightWing)
                _rotation.y += rotatePower * Time.fixedDeltaTime;
            _rigid.MoveRotation(Quaternion.Euler(_rotation.x, _rotation.y, 0));
            _rigid.MovePosition(_rigid.position + transform.forward * (speed * Time.fixedDeltaTime));
        }
    }
}