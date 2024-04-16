using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string MusicPrefs = "MusicPrefs";
    private static readonly string SoundEffectPrefs = "SoundEffectPrefs";
    
    private float backgroundFloat, soundsEffectFloat;
    //connect audio
    public AudioSource backgroundAudio;
    public AudioSource soundEffectAudio;

    void Awake() {
        ContinueSettings();
    }

    private void ContinueSettings() {

        backgroundFloat = PlayerPrefs.GetFloat(MusicPrefs);
        soundsEffectFloat = PlayerPrefs.GetFloat(SoundEffectPrefs);

        backgroundAudio.volume = backgroundFloat;
        soundEffectAudio.volume = soundsEffectFloat;
    }
}
