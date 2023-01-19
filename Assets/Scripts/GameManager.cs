using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField]
  private bool _isGameOver;
  public bool isCoopMode = false;

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
        SceneManager.LoadScene(1); // Coop Game Scene
      }
    }


    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
  }

  public void GameOver()
  {
    _isGameOver = true;
  }


}
