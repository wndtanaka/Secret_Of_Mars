using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [Header("Bools")]
    public bool gameScene;
    public bool showOptions;
    public bool pause;
    public bool fullScreenToggle;
    public bool ismute;

    [Header("Resolutions")]
    public int index;
    public int[] resX, resY;
    public Dropdown resolutionDropdown;
    public Toggle fullScreenTog;


    [Header("GUI Elements")]
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public GameObject shopManager;

    [Header("References")]
    public Slider volumeSlider;
    public AudioSource music;
    private static float holdingVolume;
    private static int holdResolution;
    private int currentResWidth;

    private void Start()
    {
        Time.timeScale = 1;
        if (Screen.fullScreen)
        {
            fullScreenToggle = true;
            fullScreenTog.isOn = true;
        }
        else
        {
            fullScreenToggle = false;
            fullScreenTog.isOn = false;
        }

        if (holdResolution == 0)  // first time start game or start again after quiting
        {
            ScreenResolution();
        }
        else  // changed resolution of restart game
        {
            resolutionDropdown.value = holdResolution;
            Screen.SetResolution(resX[holdResolution], resY[holdResolution], fullScreenToggle);
        }

        if (volumeSlider != null && AudioListener.volume != 0)
        {
            volumeSlider.value = AudioListener.volume;
            ismute = false;
        }
        if (volumeSlider != null && AudioListener.volume == 0)
        {
            volumeSlider.value = AudioListener.volume;
            ismute = true;
        }

    }

    public void Default()
    {
        DefaultVolume();
        DefaultFullScreen();
        DefaultResolution();
    }

    void DefaultVolume()
    {
        ismute = false;
        holdingVolume = 1;
        volumeSlider.value = holdingVolume;
        AudioListener.volume = holdingVolume;
    }


    void DefaultFullScreen()
    {
        fullScreenTog.isOn = true;
        fullScreenToggle = true;
    }

    void DefaultResolution()
    {
        resolutionDropdown.value = 2;
        Screen.SetResolution(resX[2], resY[2], fullScreenToggle);
    }

    void ScreenResolution()
    {
        // get current screen resolution and set it as game resolution
        currentResWidth = Screen.currentResolution.width;
        if (currentResWidth > 320 && currentResWidth < 1000)
        {
            resolutionDropdown.value = 0;
            Screen.SetResolution(resX[0], resY[0], fullScreenToggle);
        }
        if (currentResWidth > 1000 && currentResWidth < 1200)
        {
            resolutionDropdown.value = 1;
            Screen.SetResolution(resX[1], resY[1], fullScreenToggle);
        }
        if (currentResWidth > 1200 && currentResWidth < 1600)
        {
            resolutionDropdown.value = 2;
            Screen.SetResolution(resX[2], resY[2], fullScreenToggle);
        }
        if (currentResWidth > 1600 && currentResWidth < 1900)
        {
            resolutionDropdown.value = 3;
            Screen.SetResolution(resX[3], resY[3], fullScreenToggle);
        }
        if (currentResWidth > 1900 && currentResWidth < 2500)
        {
            resolutionDropdown.value = 4;
            Screen.SetResolution(resX[4], resY[4], fullScreenToggle);
        }
        if (currentResWidth > 2500)
        {
            resolutionDropdown.value = 5;
            Screen.SetResolution(resX[5], resY[5], fullScreenToggle);
        }
        holdResolution = resolutionDropdown.value;
    }


    public void Quit()  // quit button
    {
        Application.Quit();
    }

    public void ShowOptions()
    {
        // main menu show options button
        if (optionsMenu.activeSelf == false)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
    }

    public void ShowOptionsPause()
    {
        // show Options menu when Pause menu is active
        if (mainMenu.activeSelf == true)
        {
            if (optionsMenu.activeSelf == false && Time.timeScale == 0)
            {
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(true);
                mainMenu.SetActive(false);
            }
        }
        else
        {
            if (optionsMenu.activeSelf == false && Time.timeScale == 0)
            {
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(true);
            }
            if (optionsMenu.activeSelf == true && Time.timeScale == 0)
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    public void BackToMain()
    {
        // create a temporary reference to the current scene
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        // if it's in Start menu
        if (currentScene == 0)
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else  // if it's in Game scene
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            if (shopManager != null && shopManager.activeSelf == false)
            {
                shopManager.SetActive(true);
            }
            Time.timeScale = 1;
        }
    }

    public void VolumeChanged()  // Options Menu volume slider
    {
        if (ismute == false)
        {
            if (AudioListener.volume != volumeSlider.value)
            {
                AudioListener.volume = volumeSlider.value;
                holdingVolume = volumeSlider.value;
            }
        }
        else
        {
            volumeSlider.value = 0;
            AudioListener.volume = 0;
        }

    }

    public void Mute()  // Options Menu mute button
    {
        ismute = !ismute;
        if (ismute == false)
        {
            volumeSlider.value = holdingVolume;
            AudioListener.volume = holdingVolume;
        }
        else
        {
            holdingVolume = volumeSlider.value;
            volumeSlider.value = 0;
            AudioListener.volume = 0;
        }
        Debug.Log("Mute: " + ismute);
    }


    public void FullScreen()  // Options Menu fullscreen toggle
    {
        if (fullScreenTog.isOn)
        {
            fullScreenToggle = true;
            Screen.fullScreen = true;
        }
        else
        {
            fullScreenToggle = false;
            Screen.fullScreen = false;
        }
    }

    public void Resolution()  // Options Menu resolution dropdown
    {
        if (fullScreenTog.isOn)
        {
            fullScreenToggle = true;
        }
        else
        {
            fullScreenToggle = false;
        }
        index = resolutionDropdown.value;
        Screen.SetResolution(resX[index], resY[index], fullScreenToggle);
        holdResolution = resolutionDropdown.value;
    }

    public void ShowPause()  // activate Pause Menu
    {
        if (pauseMenu.activeSelf == false)
        {
            pauseMenu.SetActive(true);
            mainMenu.SetActive(false);
            if (shopManager != null && shopManager.activeSelf)
            { shopManager.SetActive(false); }
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            mainMenu.SetActive(true);
            if (shopManager != null && !shopManager.activeSelf)
            { shopManager.SetActive(false); }
            shopManager.SetActive(true);
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        // press ESC will quit game, press P will show Pause Menu
        if (!optionsMenu.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                ShowPause();
            }
        }
    }

    public void EnterGame()  // Options Menu enter button
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
        else
        {
            optionsMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()  // Pause Menu resume button
    {
        if (Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            mainMenu.SetActive(true);
            if (shopManager != null && shopManager.activeSelf == false)
            {
                shopManager.SetActive(true);
            }
            Time.timeScale = 1;
        }
    }

    public void Restart()  // Pause Menu restart button
    {
        WaveSpawner.numberOfEnemies = 0;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void FinalStage()
    {
        WaveSpawner.numberOfEnemies = 0;
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
}
