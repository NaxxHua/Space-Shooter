using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void LoadSinglePlayerGame()
  {
    SceneManager.LoadScene(1); // Game Scene
  }

  public void LoadCoopGame()
  {
    SceneManager.LoadScene(2); // Game Scene
  }
}
