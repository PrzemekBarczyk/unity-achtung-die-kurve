using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Text playMusicText;
    [SerializeField] Text playSoundText;

    [SerializeField] UnityEvent OnMusicPlay;
    [SerializeField] UnityEvent OnMusicStop;

    [SerializeField] UnityEvent OnSoundPlay;
    [SerializeField] UnityEvent OnSoundStop;

    bool playMusic = true;
    bool playSound = true;

    void Start()
    {
        TurnMusic();
        TurnSound();
    }

    public void SwitchMusicOption()
	{
        playMusic = !playMusic;
        TurnMusic();
	}

    void TurnMusic()
	{
        if (playMusic)
        {
            OnMusicPlay.Invoke();
            playMusicText.text = "Music:\t\ton";
        }
        else
        {
            OnMusicStop.Invoke();
            playMusicText.text = "Music:\t\toff";
        }
    }

    public void SwitchSoundOption()
	{
        playSound = !playSound;
        TurnSound();
    }

    void TurnSound()
	{
        if (playSound)
        {
            OnSoundPlay.Invoke();
            playSoundText.text = "Sound:\ton";
        }
        else
        {
            OnSoundStop.Invoke();
            playSoundText.text = "Sound:\toff";
        }
    }
}
