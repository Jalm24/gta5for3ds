using UnityEngine;

public class disableHome : MonoBehaviour
{
    void Start()
    {
            UnityEngine.N3DS.HomeButton.Disable();
    }
}