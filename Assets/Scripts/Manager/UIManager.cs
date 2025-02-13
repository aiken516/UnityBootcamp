using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currentHitValueText;

    [SerializeField] private TextMeshProUGUI _valueUpCostText;
    [SerializeField] private TextMeshProUGUI _valueUpCountText;

    [SerializeField] private TextMeshProUGUI _robotUpCostText;
    [SerializeField] private TextMeshProUGUI _robotUpCountText;

    [SerializeField] private TextMeshProUGUI _superRobotUpCostText;
    [SerializeField] private TextMeshProUGUI _superRobotUpCountText;

    [SerializeField] private Image _upgradeImage;
    [SerializeField] private TextMeshProUGUI _upgradeCostText;

    private void Awake()
    {
        instance = this;
    }

    public void SetScoreBoardText(int score, int currentHitValue, int upgradeCount)
    {
        _scoreText.text = $"����: {score}";
        _currentHitValueText.text = $"���� �� ���� : {currentHitValue} X {upgradeCount}";
    }

    public void SetValueUpButton(int valueUpCost, int valueUpCount)
    {
        _valueUpCostText.text = $"{valueUpCost}";
        _valueUpCountText.text = $"+{valueUpCount}";
    }

    public void SetRobotUpButton(int robotUpCost, int robotUpCount)
    {
        _robotUpCostText.text = $"{robotUpCost}";
        _robotUpCountText.text = $"+{robotUpCount}";
    }

    public void SetSuperRobotUpButton(int superRobotUpCost, int superRobotUpCount)
    {
        _superRobotUpCostText.text = $"{superRobotUpCost}";
        _superRobotUpCountText.text = $"+{superRobotUpCount}";
    }

    public void SetUpgradeButton(int upgradeCount, int upgradeCost)
    {
        _upgradeCostText.text = $"��ȭ + {upgradeCount}(����Ȯ��: {100f / upgradeCount}%)\n{upgradeCost}";
    }
}
