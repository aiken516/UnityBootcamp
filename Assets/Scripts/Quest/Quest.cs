using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private QuestData _questData;

    private int _questAmount = 0;
    private bool _isClear = false;

    public delegate void OnClear();
    private OnClear _onClear;

    public void Init(QuestData questData, OnClear onClear)
    {
        QuestSystem.instance.OnGetItem += HandleGetItem;
        _questData = questData;
        _onClear = onClear;
    }

    private void HandleGetItem(string name, int amount)
    {
        if (_questData.Requirement.QuestObjective == name)
        {
            _questAmount += amount;
            if (_questAmount >= _questData.Requirement.QuestAmount)
            {
                _isClear = true;
                _onClear();
            }
        }
    }
}
