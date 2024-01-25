using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    private const string SoundVolumeKey = "SoundVolume";

    
    private void Start()
    {
        float savedSoundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, 1.0f);
        myMixer.SetFloat("Music", savedSoundVolume);
        musicSlider.value = savedSoundVolume;
        musicSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
    }

    void OnSoundVolumeChanged(float newVolume)
    {
        // Set the sound volume and save it to PlayerPrefs
        myMixer.SetFloat("Music", Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat(SoundVolumeKey, newVolume);
        PlayerPrefs.Save(); // Ensure changes are saved immediately
    }
}
