using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField]
  private bool _isGameOver;
  public bool isCoopMode = false;
  [SerializeField]
  private GameObject _pauseMenuPanel;

  private Animator _pauseAnimator;

  private void Start()
  {
    _pauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
    _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
  }

  private void Update()
  {
    if (isCoopMode == false)
    {
      if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
      {
        SceneManager.LoadScene(1); // Single Game Scene
      }
    }

    if (isCoopMode == true)
    {
      if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
      {
        SceneManager.LoadScene(2); // Coop Game Scene
      }
    }

    if (Input.GetKeyDown(KeyCode.Space) && _isGameOver == true)
    {
      SceneManager.LoadScene(0); // Main Menu Scene
    }


    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }

    if (Input.GetKeyDown(KeyCode.P))
    {
      _pauseMenuPanel.SetActive(true);
      _pauseAnimator.SetBool("isPaused", true);
      Time.timeScale = 0;
    }

  }

  public void ResumeGame()
  {
    _pauseMenuPanel.SetActive(false);
    Time.timeScale = 1f;
  }

  public void GameOver()
  {
    _isGameOver = true;
  }


}
