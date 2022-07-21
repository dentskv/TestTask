using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuViewController : MonoBehaviour
{
    [Inject] private TweenManager tweenManager;
    [Inject] private AudioManager audioManager;

    [SerializeField] private RectTransform SettingsBackground;
    [SerializeField] private RectTransform MainBackground;
    
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button backButton;
    
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    
    [SerializeField] private Image fadingPanel;

    private void Awake()
    {
        SettingsBackground.sizeDelta = new Vector2(MainBackground.rect.width + 5, default);
        SettingsBackground.anchoredPosition = new Vector2(MainBackground.position.x,default);
        fadingPanel.material.color = Color.black;
    }

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        
        musicToggle.onValueChanged.AddListener(delegate { OnMusicToggleClick(musicToggle); });
        sfxToggle.onValueChanged.AddListener(delegate { OnSFXToggleClick(sfxToggle); });
        
        tweenManager.FadeOut(fadingPanel);
        
        sfxToggle.isOn = PlayerPrefs.GetInt("SFX") == 1;
        musicToggle.isOn = PlayerPrefs.GetInt("Music") == 1;
    }

    private void OnSFXToggleClick(Toggle toggle)
    {
        audioManager.TurnSFX(toggle.isOn);
    }

    private void OnMusicToggleClick(Toggle toggle)
    {
        audioManager.TurnMusic(toggle.isOn);
    }

    private void OnPlayButtonClick()
    {
        audioManager.PlayClickSound();
        tweenManager.FadeInToLoadScene(fadingPanel, 1);
    }
    
    private void OnSettingsButtonClick()
    {
        audioManager.PlayClickSound();
        tweenManager.ScrollMenuLeft(MainBackground, SettingsBackground);
    }

    private void OnBackButtonClick()
    {
        audioManager.PlayClickSound();
        tweenManager.ScrollMenuRight(MainBackground, SettingsBackground);
    }
}
