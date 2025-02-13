using UnityEngine;

[CreateAssetMenu(fileName = "QuestReward", menuName = "Quest/QuestReward")]
public class QuestReward : MonoBehaviour
{
    [SerializeField] public string RewardName;
    [SerializeField] public int RewardAmount;
}
