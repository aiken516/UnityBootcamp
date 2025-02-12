using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerArmature;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _playerDeadParticle;

    public PlayerDeadEvent PlayerDeadEvent = new PlayerDeadEvent();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerDeadEvent.PlayerDead += new EventHandler(PlayerDead);
    }

    public void PlayerOn()
    {
        _player.SetActive(true);
        _mainCamera.SetActive(false);
    }

    public void PlayerOff()
    {
        _player.SetActive(false);
        _mainCamera.SetActive(true);
    }

    public void PlayerDead(object sender, EventArgs e)
    {
        _playerDeadParticle.SetActive(true);
        _playerDeadParticle.transform.position = _playerArmature.transform.position;
        _playerArmature.SetActive(false);
        Invoke(nameof(PlayerOff), 2f);
    }
}

public class PlayerDeadEvent
{
    public event EventHandler PlayerDead;
    public void OnPlayerDead()
    {
        PlayerDead(this, EventArgs.Empty);
    }
}