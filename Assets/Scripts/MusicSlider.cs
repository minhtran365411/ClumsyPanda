using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPrefs = "MusicPrefs";
    private static readonly string SoundEffectPrefs = "SoundEffectPrefs";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundsEffectFloat;

    //connect audio
    public AudioSource backgroundAudio;
    public AudioSource soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) {
            backgroundFloat = .125f;
            soundsEffectFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundsEffectFloat;
            PlayerPrefs.SetFloat(MusicPrefs, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPrefs, soundsEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        } else {
           backgroundFloat = PlayerPrefs.GetFloat(MusicPrefs);
            backgroundSlider.value = backgroundFloat;
           soundsEffectFloat = PlayerPrefs.GetFloat(SoundEffectPrefs);
           soundEffectsSlider.value = soundsEffectFloat;
        }
        
    }

    public void SaveSoundSetting() {
        PlayerPrefs.SetFloat(MusicPrefs, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPrefs, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus) {
        if(!inFocus) {
            SaveSoundSetting();
        }
    }

    public void UpdateSound() {
        backgroundAudio.volume = backgroundSlider.value;
        soundEffectAudio.volume = soundEffectsSlider.value;
    }

}
