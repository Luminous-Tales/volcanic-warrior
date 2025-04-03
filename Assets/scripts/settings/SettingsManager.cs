using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Canvas menu;
    public Canvas hud;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        ApplySettings();
    }
    public void SettingsClose()
    {
        gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
    }

    public void ApplySettings()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }
}
