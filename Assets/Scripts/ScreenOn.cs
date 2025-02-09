using UnityEngine;
using UnityEngine.Video;

public class ScreenOn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<VideoPlayer>().Play();
    }

}
