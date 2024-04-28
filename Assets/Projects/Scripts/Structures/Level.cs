using UnityEngine;

namespace Projects.Scripts.Structures
{
    public class Level : MonoBehaviour
    {
        public Collider[] Collider { get; private set; }

        private void Start()
        {
            Collider = GetComponentsInChildren<Collider>();
        }

        public void SetColliderActive(bool active)
        {
            foreach (var col in Collider) col.enabled = active;
        }
    }
}