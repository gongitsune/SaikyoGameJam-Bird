using UnityEngine;

namespace Projects.Scripts.UI
{
    public class HeightMeter : MonoBehaviour
    {
        [SerializeField] GameObject PlayerOBJ;
        [SerializeField] float PlayerHighHeight;
        [SerializeField] float PlayerLowHeight;
        [SerializeField] float HeightMeterHigh = 130;
        [SerializeField] float HeightMeterLow = 130;
        [SerializeField] float AddMeterHeight;
        private void Update()
        {
            float PlayerPosY = PlayerOBJ.transform.position.y;
            PlayerPosY = Mathf.Clamp(PlayerPosY, PlayerLowHeight, PlayerHighHeight);
            float PlayerPosYRatio = (PlayerPosY - PlayerLowHeight) / (PlayerHighHeight - PlayerLowHeight);
            Vector3 MeterPosison;
            MeterPosison = this.transform.position;
            MeterPosison.y = ((HeightMeterHigh + HeightMeterLow) * PlayerPosYRatio) + AddMeterHeight;
            this.transform.position = MeterPosison;
        }
    }

    
}