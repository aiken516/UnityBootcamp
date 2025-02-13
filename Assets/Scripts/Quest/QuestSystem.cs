using System;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;

    public event Action<string, int> OnGetItem;


    private void Awake()
    {
        instance = this;
    }

    public void GetItem(string name, int amount)
    {
        OnGetItem.Invoke(name, amount);
    }

}
