using TMPro;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceBGM;
    [SerializeField] private TextMeshProUGUI _bgmButton;

    private bool _isBGMPlaying;

    private void Start()
    {
        _audioSourceBGM.Play();
    }

    public void OnBGMButtonClick()
    {
        if (_isBGMPlaying)
        {
            _audioSourceBGM.Pause();
            _bgmButton.text = "Off";
        }
        else 
        {
            _audioSourceBGM.UnPause();
            _bgmButton.text = "On";
        }

        _isBGMPlaying = !_isBGMPlaying;
    }

}
