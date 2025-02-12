using UnityEngine;
using UnityEngine.Video;

public class ScreenOn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<VideoPlayer>().Play();
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.instance.PlayerDeadEvent.OnPlayerDead();
        }
    }

}
