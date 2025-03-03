using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    public void SetMaster(float masterVolume)
    {
        _mixer.audioMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
    }

    public void SetMusic(float musicVolume)
    {
        _mixer.audioMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
    }

    public void SetEffects(float effectsVolume)
    {
        _mixer.audioMixer.SetFloat("Effects", Mathf.Log10(effectsVolume) * 20);
    }
}