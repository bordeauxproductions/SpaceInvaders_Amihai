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

    void Awake()
    {
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    private void Pause()
    {
        pauseButton.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f; //pauses the game - the speed of the game generally (how fast the time passes)
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
    }

    private void ReactTime()
    {

    }
}
