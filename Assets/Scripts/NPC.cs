using UnityEngine;
using UnityEngine.Video;

public class NPC : MonoBehaviour
{
    [SerializeField] private QuestData _questData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Quest quest = new Quest();
            quest.Init(_questData, null);


        }
    }
}
