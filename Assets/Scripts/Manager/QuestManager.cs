using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private List<Quest> _activeQuestList = new(); 

    private void Awake()
    {
        instance = this;
    }

    public void AddQuest(Quest quest)
    {
        _activeQuestList.Add(quest);
    }


}
