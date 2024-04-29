using UnityEngine;

namespace Projects.Scripts.Player
{
    public class PlayerInput
    {
        public bool RightWing { get; private set; }
        public bool LeftWing { get; private set; } 
        
        public void CheckInput()
        {
            LeftWing = Input.GetKey(KeyCode.M);
            RightWing = Input.GetKey(KeyCode.Z);
        }
    }
}