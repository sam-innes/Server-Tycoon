using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OptionsMenuManager : MonoBehaviour {
    public Canvas options;
    public Canvas pause;
    public GameObject player;
    public AudioSource music;

    public Toggle fullScreenToggle;
    public Dropdown resDropDown;
    public Dropdown textureQualityDropDown;
    public Dropdown aaDropDown;
    public Dropdown vsyncDropDown;
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    public Resolution[] resolutions;

    public GameSettings gameSettings;

    private void OnEnable()
    {
        gameSettings = new GameSettings();

        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resDropDown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropDown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        aaDropDown.onValueChanged.AddListener(delegate { OnAAChange(); });
        vsyncDropDown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        soundVolumeSlider.onValueChanged.AddListener(delegate { OnSoundVolumeChange(); });

        resolutions = Screen.resolutions;

        foreach (Resolution res in resolutions)
        {
            resDropDown.options.Add(new Dropdown.OptionData(res.ToString()));
        }
        LoadSettings();
    }
    void Start()
    {
        LoadSettings();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            options.gameObject.SetActive(false);
            player.SetActive(true);
        }
    }

    public void OnFullScreenToggle()
    {
        gameSettings.fullScreen = Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resDropDown.value].width, resolutions[resDropDown.value].height, Screen.fullScreen);
        gameSettings.resolution = resDropDown.value;
    }

    public void OnTextureQualityChange()
    {
        gameSettings.textureQuality = QualitySettings.masterTextureLimit = textureQualityDropDown.value;
    }

    public void OnAAChange()
    {
        gameSettings.aa = QualitySettings.antiAliasing = (int)Mathf.Pow(2, aaDropDown.value);
    }

    public void OnVSyncChange()
    {
        gameSettings.vsync = QualitySettings.vSyncCount = vsyncDropDown.value;
    }

    public void OnMusicVolumeChange()
    {
        gameSettings.musicVol = music.volume = musicVolumeSlider.value;
    }

    public void OnSoundVolumeChange()
    {
        gameSettings.soundVol = soundVolumeSlider.value;
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gameSettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gameSettings.json"));
        musicVolumeSlider.value = gameSettings.musicVol;
        soundVolumeSlider.value = gameSettings.soundVol;
        aaDropDown.value = gameSettings.aa;
        vsyncDropDown.value = gameSettings.vsync;
        textureQualityDropDown.value = gameSettings.textureQuality;
        resDropDown.value = gameSettings.resolution;
        fullScreenToggle.isOn = gameSettings.fullScreen;

    }

    public void Apply()
    {
        SaveSettings();
        options.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }
    public void Back()
    {
        options.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        LoadSettings();
    }
}
