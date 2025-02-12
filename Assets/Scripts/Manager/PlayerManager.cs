using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _mainCamera;

    public PlayerDeadEvent PlayerDeadEvent = new PlayerDeadEvent();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerDeadEvent.PlayerDead += new EventHandler(PlayerOff);
    }

    public void PlayerOn()
    {
        _player.SetActive(true);
        _mainCamera.SetActive(false);
    }

    public void PlayerOff(object sender, EventArgs e)
    {
        _player.SetActive(false);
        _mainCamera.SetActive(true);
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