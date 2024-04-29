using TMPro;
using UnityEngine;

namespace Projects.Scripts.UI
{
    public class ScoreMeter : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        
        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}