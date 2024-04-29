using UnityEngine;

namespace Projects.Scripts.Structures
{
    public class ScoreWheel : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";

        public bool IsCollected { get; set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(playerTag)) return;

            // TODO: エフェクト追加
            gameObject.SetActive(false);
            IsCollected = true;
        }
    }
}