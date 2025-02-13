using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Quest/QuestData")]
public class QuestData : ScriptableObject
{
    [SerializeField] public QuestRequirement Requirement;
    [SerializeField] public QuestReward Reward;

    [Header("Info")]
    [SerializeField] public string Title;
    [SerializeField] public string Object;
    [SerializeField][TextArea] public string Description;
}
