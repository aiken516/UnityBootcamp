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

    public int Score = 0;

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

        SetScore();
    }

    public void SetScore()
    {
        _scoreText.text = $"점수: {Score}";
        _currentHitValueText.text = $"명중 당 점수 : {CurrentHitValue} X {UpgradeCount}";

        _valueUpCostText.text = $"{_valueUpCost}";
        _robotUpCostText.text = $"{_robotUpgradeCost}";
        _superRobotUpCostText.text = $"{_superRobotUpgradeCost}";

        _upgradeCostText.text = $"강화 + {UpgradeCount}(성공확률: {100f / UpgradeCount}%)\n{_upgradeCost}";

        _robotGameObject.SetActive(RobotUpgradeCount > 0);
        _superRobotGameObject.SetActive(SuperRobotUpgradeCount > 0);
    }

    public void ValueUp()
    {
        if (Score >= _valueUpCost)
        {
            Score -= _valueUpCost;
            _valueUpCost = (int)(100 * Mathf.Pow(1.2f, (CurrentHitValue - 10)/5));

            CurrentHitValue += 5;
        }
        SetScore();
    }

    public void Robot()
    {
        if (Score >= _robotUpgradeCost)
        {
            Score -= _robotUpgradeCost;
            _robotUpgradeCost = (int)(1000 * Mathf.Pow(1.2f, RobotUpgradeCount));

            RobotUpgradeCount += 1;
        }
        SetScore();
    }

    public void SuperRobot()
    {
        if (Score >= _superRobotUpgradeCost)
        {
            Score -= _superRobotUpgradeCost;
            SuperRobotUpgradeCount += 1;
            _superRobotUpgradeCost = (int)(5000 * Mathf.Pow(1.2f, SuperRobotUpgradeCount));

            RenderSettings.skybox = skyBoxMaterial;
        }
        SetScore();
    }

    public void OnUpgradeButtonClick()
    {
        if (Score >= _upgradeCost)
        {
            Score -= _upgradeCost;

            if (Random.Range(0, 100) <= 100 / UpgradeCount)
            {
                UpgradeCount += 1;
                _upgradeCost = (int)(10000 * Mathf.Pow(1.4f, UpgradeCount));
            }
        }
        SetScore();
    }

    public void OnClickDataSave()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("CurrentHitValue", CurrentHitValue);
        PlayerPrefs.SetInt("RobotUpgradeCount", RobotUpgradeCount);
        PlayerPrefs.SetInt("SuperRobotUpgradeCount", SuperRobotUpgradeCount);

        _loadButton.interactable = true;
    }

    public void OnClickDataLoad()
    {
        Score = PlayerPrefs.GetInt("Score");
        CurrentHitValue = PlayerPrefs.GetInt("CurrentHitValue");
        RobotUpgradeCount = PlayerPrefs.GetInt("RobotUpgradeCount");
        SuperRobotUpgradeCount = PlayerPrefs.GetInt("SuperRobotUpgradeCount");

        _valueUpCost = (int)(100 * Mathf.Pow(1.2f, (CurrentHitValue - 10) / 5));
        _robotUpgradeCost = (int)(1000 * Mathf.Pow(1.2f, RobotUpgradeCount));
        _superRobotUpgradeCost = (int)(5000 * Mathf.Pow(1.2f, SuperRobotUpgradeCount));
        _upgradeCost = (int)(10000 * Mathf.Pow(1.4f, UpgradeCount));



        SetScore();
    }

    public void OnClickDataDelete()
    {
        PlayerPrefs.DeleteAll();

        _loadButton.interactable = false;
    }
}
