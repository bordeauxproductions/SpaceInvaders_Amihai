using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource gameTheme;

    void Awake()
    {
        gameTheme.Play();
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    private void Pause()
    {
        gameTheme.Pause();
        pauseButton.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f; //pauses the game - the speed of the game generally (how fast the time passes)
    }

    private void Resume()
    {
        gameTheme.UnPause();
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
    }
}
