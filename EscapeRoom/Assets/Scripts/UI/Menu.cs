using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    GameObject menuPanel;
    public Image overlay;
    public Color pauseColor;
    public AudioSource musicSource;
    public AudioSource FXSource;
    //bool gameStarted;

    void Awake()
    {
        menuPanel = GameObject.Find("Canvas").transform.Find("Menu").transform.Find("MenuPanel").gameObject;
    }

    //void Start()
    //{
    //    if (LevelManager.i == 0)
    //    {
    //        menuPanel.SetActive(true);
    //    }
    //    else if (LevelManager.i == 1)
    //    {
    //        StartGame();
    //    }
    //}

    public void PlayGame()
    {
        menuPanel.SetActive(false);
        //gameStarted = true;
    }

    public void PauseGame()
    {
        overlay.color = pauseColor;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void SetMusicVolume(Slider slider)
    {
        musicSource.volume = slider.value;
    }

    public void SetFXVolume(Slider slider)
    {
        FXSource.volume = slider.value;
    }

    //public void RestartLevel()
    //{
    //    Time.timeScale = 1;
    //    //LevelManager.i = 1;
    //    SceneManager.LoadScene(0);
    //}

    public void Quit()
    {
        overlay.color = Color.black;
        Debug.Log("Quitter!");
        musicSource.volume = 0;
        FXSource.volume = 0;
        Application.Quit();
    }
}
