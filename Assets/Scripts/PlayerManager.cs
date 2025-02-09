using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _mainCamera;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerOn()
    {
        _player.SetActive(true);
        _mainCamera.SetActive(false);
    }
}
