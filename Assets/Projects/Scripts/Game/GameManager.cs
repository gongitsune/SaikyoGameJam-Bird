using Projects.Scripts.Common;
using Projects.Scripts.UI;
using UnityEngine;

namespace Projects.Scripts.Game
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private ScoreMeter scoreMeter;
        
        public int NumOfCollectedWheel { get; private set; }

        public void AddScore()
        {
            NumOfCollectedWheel++;
            scoreMeter.SetScore(NumOfCollectedWheel);
        }
    }
}