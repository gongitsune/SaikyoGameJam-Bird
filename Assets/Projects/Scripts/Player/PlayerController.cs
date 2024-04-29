using Projects.Scripts.Game;
using UnityEngine;

namespace Projects.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed, rotatePower, verticalPower;
        [SerializeField] private float rotationThreshold = 0.1f;
        [SerializeField] private string scoreWheelTag = "ScoreWheel";
        private GameManager _gameManager;

        private PlayerInput _input;
        private Rigidbody _rigid;
        private Vector2 _rotation;
        private float _speedMultiplier = 1;

        private void Start()
        {
            _input = new PlayerInput();
            _gameManager = GameManager.Instance;
            TryGetComponent(out _rigid);
        }

        private void Update()
        {
            _input.CheckInput();
        }

        private void FixedUpdate()
        {
            if (_input.LeftWing && _input.RightWing)
            {
                _rotation.x -= verticalPower * Time.fixedDeltaTime;
            }
            else if (!_input.LeftWing && !_input.RightWing)
            {
                _rotation.x += verticalPower * Time.fixedDeltaTime;
                if (_rotation.x > rotationThreshold)
                    _rotation.x = rotationThreshold;
            }

            if (_input.LeftWing)
                _rotation.y -= rotatePower * Time.fixedDeltaTime;
            if (_input.RightWing)
                _rotation.y += rotatePower * Time.fixedDeltaTime;
            _rigid.MoveRotation(Quaternion.Euler(_rotation.x, _rotation.y, 0));

            if (_rotation.x > 0)
            {
                _speedMultiplier *= 1.01f;
                if (_speedMultiplier > 2f)
                    _speedMultiplier = 2f;
            }
            else
            {
                _speedMultiplier = 1;
            }

            _rigid.velocity = transform.forward * (speed * _speedMultiplier * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(scoreWheelTag)) return;

            _gameManager.AddScore();
        }
    }
}