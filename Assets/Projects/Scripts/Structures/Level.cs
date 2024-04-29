using System.Linq;
using UnityEngine;

namespace Projects.Scripts.Structures
{
    public class Level : MonoBehaviour
    {
        private Collider[] _collider;
        private ScoreWheel[] _scoreWheels;

        private void Awake()
        {
            _collider = GetComponentsInChildren<Collider>();
            _scoreWheels = GetComponentsInChildren<ScoreWheel>();
        }

        public void OnRelease()
        {
            foreach (var wheel in _scoreWheels)
                wheel.IsCollected = false;
        }

        public void SetScoreWheelActive(bool active)
        {
            foreach (var wheel in from wheel in _scoreWheels where !wheel.IsCollected select wheel)
                wheel.gameObject.SetActive(active);
        }

        public void SetColliderActive(bool active)
        {
            foreach (var col in _collider)
                col.enabled = active;
        }
    }
}