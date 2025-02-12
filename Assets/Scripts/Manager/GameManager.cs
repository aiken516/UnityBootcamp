using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _currentHitValueText;

    [SerializeField] private TextMeshProUGUI _valueUpCostText;
    [SerializeField] private TextMeshProUGUI _robotUpCostText;
    [SerializeField] private TextMeshProUGUI _superRobotUpCostText;

    [SerializeField] private Image _upgradeImage;
    [SerializeField] private TextMeshProUGUI _upgradeCostText;

    //[SerializeField] private List<Texture> _upgradeSprites = new();


    [SerializeField] private GameObject _robotGameObject;
    [SerializeField] private GameObject _superRobotGameObject;

    [SerializeField] private Material skyBoxMaterial;

    [SerializeField] private Button _loadButton;

    private int _score = 0;

    public int CurrentHitValue = 10;

    public int RobotUpgradeCount = 0;

    public int SuperRobotUpgradeCount = 0;

    public int UpgradeCount = 1;

    private int _valueUpCost = 100;
    private int _robotUpgradeCost = 1000;
    private int _superRobotUpgradeCost = 5000;
    private int _upgradeCost = 10000;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("CurrentHitValue") &&
            PlayerPrefs.HasKey("RobotUpgradeCount") && PlayerPrefs.HasKey("SuperRobotUpgradeCount"))
        {
            _loadButton.interactable = true;

        }
        else
        {
            _loadButton.interactable = false;
        }

        _robotGameObject.SetActive(false);
        _superRobotGameObject.SetActive(false);

        PlayerManager.instance.PlayerDeadEvent.PlayerDead += RobotDestroy;
    }

    public void ScorePlus(int score)
    {
        _score += score;
        UIManager.instance.SetScoreBoardText(_score, CurrentHitValue, UpgradeCount);
    }

    public void ValueUp()
    {
        if (_score >= _valueUpCost)
        {
            _score -= _valueUpCost;
            _valueUpCost = (int)(100 * Mathf.Pow(1.2f, (CurrentHitValue - 10)/5));

            CurrentHitValue += 5;
        }

        UIManager.instance.SetValueUpButton(_valueUpCost, CurrentHitValue - 10);
        UIManager.instance.SetScoreBoardText(_score, CurrentHitValue, UpgradeCount);
    }

    public void Robot()
    {
        if (_score >= _robotUpgradeCost)
        {
            _score -= _robotUpgradeCost;
            _robotUpgradeCost = (int)(1000 * Mathf.Pow(1.2f, RobotUpgradeCount));

            RobotUpgradeCount += 1;

            _robotGameObject.SetActive(true);
            UIManager.instance.SetRobotUpButton(_robotUpgradeCost, RobotUpgradeCount);
        }
    }

    public void SuperRobot()
    {
        if (_score >= _superRobotUpgradeCost)
        {
            _score -= _superRobotUpgradeCost;
            SuperRobotUpgradeCount += 1;

            _superRobotUpgradeCost = (int)(5000 * Mathf.Pow(1.2f, SuperRobotUpgradeCount));

            _superRobotGameObject.SetActive(true);
            UIManager.instance.SetRobotUpButton(_superRobotUpgradeCost, SuperRobotUpgradeCount);
        }
    }

    public void OnRobotControllButtonClick()
    {
        PlayerManager.instance.PlayerOn();
        _robotGameObject.SetActive(false);
    }

    public void OnUpgradeButtonClick()
    {
        if (_score >= _upgradeCost)
        {
            _score -= _upgradeCost;

            if (UnityEngine.Random.Range(0, 100) <= 100 / UpgradeCount)
            {
                UpgradeCount += 1;
                _upgradeCost = (int)(10000 * Mathf.Pow(1.4f, UpgradeCount));
            }
        }
        UIManager.instance.SetUpgradeButton(UpgradeCount, _upgradeCost);
        UIManager.instance.SetScoreBoardText(_score, CurrentHitValue, UpgradeCount);
    }

    public void OnClickDataSave()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.SetInt("CurrentHitValue", CurrentHitValue);
        PlayerPrefs.SetInt("RobotUpgradeCount", RobotUpgradeCount);
        PlayerPrefs.SetInt("SuperRobotUpgradeCount", SuperRobotUpgradeCount);

        _loadButton.interactable = true;
    }

    public void OnClickDataLoad()
    {
        _score = PlayerPrefs.GetInt("Score");
        CurrentHitValue = PlayerPrefs.GetInt("CurrentHitValue");
        RobotUpgradeCount = PlayerPrefs.GetInt("RobotUpgradeCount");
        SuperRobotUpgradeCount = PlayerPrefs.GetInt("SuperRobotUpgradeCount");

        _valueUpCost = (int)(100 * Mathf.Pow(1.2f, (CurrentHitValue - 10) / 5));
        _robotUpgradeCost = (int)(1000 * Mathf.Pow(1.2f, RobotUpgradeCount));
        _superRobotUpgradeCost = (int)(5000 * Mathf.Pow(1.2f, SuperRobotUpgradeCount));
        _upgradeCost = (int)(10000 * Mathf.Pow(1.4f, UpgradeCount));

        _robotGameObject.SetActive(RobotUpgradeCount > 0);
        _superRobotGameObject.SetActive(SuperRobotUpgradeCount > 0);
    }

    public void OnClickDataDelete()
    {
        PlayerPrefs.DeleteAll();

        _loadButton.interactable = false;
    }

    public void RobotDestroy(object sender, EventArgs e)
    {
        _robotGameObject.SetActive(false);
        RobotUpgradeCount = 0;
        UIManager.instance.SetRobotUpButton(_robotUpgradeCost, RobotUpgradeCount);
    }
}
