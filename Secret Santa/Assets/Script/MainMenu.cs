using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private static bool MainMenuBool = false;
    [SerializeField] private static bool Settings = false;
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject SettingMenuUI;
    [SerializeField] private AudioMixer Master;
    [SerializeField] private AudioMixer SFX;
    public void OnStart()
    {
        SceneManager.LoadScene("Testing");
    }
    public void Setting()
    {
        MainMenuBool = false;
        Settings = true;
        SettingMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }
    public void BackToMenu()
    {
        MainMenuBool = true;
        Settings = false;
        SettingMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void SetMasterVolume (float volume)
    {
        Master.SetFloat("master", volume);
    }
    public void SetSFXVolume (float volume)
    {
        SFX.SetFloat("sfx", volume);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
    public void Credits()
    {
        Debug.Log("Credits");
    }
}
