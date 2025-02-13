using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Collider))]
public class FieldItem : MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            QuestSystem.instance.GetItem(_itemName, _itemAmount);
        }
    }
}
