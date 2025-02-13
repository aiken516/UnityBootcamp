using UnityEngine;

[CreateAssetMenu(fileName = "QuestRequirement", menuName = "Quest/QuestRequirement")]
public class QuestRequirement : ScriptableObject
{
    [SerializeField] public string QuestObjective;
    [SerializeField] public int QuestAmount;
}
