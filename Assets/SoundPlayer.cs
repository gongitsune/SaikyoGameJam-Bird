using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudPlayre : MonoBehaviour
{
    private Sound soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent
            <Sound>(); // Soundコンポーネントを取得
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown( KeyCode.Space))
        {
            soundPlayer.PlaySound1();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        soundPlayer.PlaySound2();
    }
}
