using Projects.Scripts.Common;

namespace Projects.Scripts.Game
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        public int NumOfCollectedWheel { get; private set; }

        public void AddScore()
        {
            NumOfCollectedWheel++;
        }
    }
}