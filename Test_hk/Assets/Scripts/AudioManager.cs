using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject unmuteIcon;
    [SerializeField] private GameObject muteIcon;

    public void ChangeVolume()
    {
        backgroundMusic.volume = volumeSlider.value;
        if (backgroundMusic.volume == 0)
        {
            //mute
            ShowMuteButton();
        }
        else
        {
            ShowUnmuteButton();
        }
    }
    private void ShowMuteButton()
    {
        unmuteIcon.SetActive(false);
        muteIcon.SetActive(true);
    }
    private void ShowUnmuteButton()
    {
        muteIcon.SetActive(false);
        unmuteIcon.SetActive(true);
    }
}
