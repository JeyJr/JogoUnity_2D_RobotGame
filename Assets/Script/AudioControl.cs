using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AudioControl : MonoBehaviour
{

    AudioSource audioSourceGameController;
    GameController gameController;

    public AudioClip[] clips;
    public Slider volumeControl;
    public TMP_Text txtVolume;

    public bool playBGGuiMusic;
    public bool playBGGameMusic;

    private void Start()
    {
        audioSourceGameController = GetComponent<AudioSource>();
        gameController = GetComponent<GameController>();

        if (PlayerPrefs.HasKey("volume"))
        {
            volumeControl.value = PlayerPrefs.GetFloat("volume");
        }
    }

    private void Update()
    {
        if(gameController.gameStarted)
        {
            if(! audioSourceGameController.isPlaying == clips[4])
            {
                audioSourceGameController.PlayOneShot(clips[4]);
            }
        }
        else if (! gameController.gameStarted && gameController.life > 0)
        {
            if (!audioSourceGameController.isPlaying == clips[5])
            {
                audioSourceGameController.PlayOneShot(clips[5]);
            }
        }

    }
    public void PlayAudio(int clipValue)
    {
        audioSourceGameController.PlayOneShot(clips[clipValue]);
    }
    public void SaveChanges()
    {
        PlayerPrefs.SetFloat("volume", volumeControl.value);
    }
    public float Volume
    {
        get => volumeControl.value;
        set
        {
            audioSourceGameController.volume = volumeControl.value;
            txtVolume.text = "Volume: " + (volumeControl.value * 100).ToString("F0") + "%";
        }
    }
}
