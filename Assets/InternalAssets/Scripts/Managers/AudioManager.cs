using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip clickSound;
    
    private AudioSource _sfxSource;

    private void Awake()
    {
        _sfxSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("SFX") && PlayerPrefs.HasKey("Music"))
        {
            _sfxSource.mute = PlayerPrefs.GetInt("SFX") != 1;
            musicSource.mute = PlayerPrefs.GetInt("Music") != 1;
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 1);
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    public void TurnSFX(bool isOn)
    {
        _sfxSource.mute = !isOn;
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
    }
    
    public void TurnMusic(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt("Music", isOn ? 1 : 0);
    }
    
    public void PlayClickSound()
    {
        _sfxSource.PlayOneShot(clickSound);
    }
}
