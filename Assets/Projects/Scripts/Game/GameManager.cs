using Projects.Scripts.Common;

namespace Projects.Scripts.Game
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private int _numOfCollectedWheel;

        public void AddScore()
        {
            _numOfCollectedWheel++;
        }
    }
}