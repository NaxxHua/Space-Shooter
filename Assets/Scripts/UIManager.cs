using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  private Text _scoreText;
  [SerializeField]
  private Image _LivesImg;
  [SerializeField]
  private Sprite[] _liveSprites;
  [SerializeField]
  private Text _gameOverText;
  [SerializeField]
  private Text _restartText;

  private GameManager _gameManager;

  void Start()
  {
    _scoreText.text = "Score: " + 0;
    _gameOverText.gameObject.SetActive(false);
    _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

    if (_gameManager == null)
    {
      Debug.LogError("GameManager is null");
    }
  }

  public void UpdateScore(int playerScore)
  {
    _scoreText.text = "Score: " + playerScore.ToString();
  }

  public void UpdateLives(int currentLives)
  {
    _LivesImg.sprite = _liveSprites[currentLives];

    if (currentLives <= 0)
    {
      GameOverSequence();
    }
  }

  void GameOverSequence()
  {
    _gameManager.GameOver();
    _gameOverText.gameObject.SetActive(true);
    _restartText.gameObject.SetActive(true);
    StartCoroutine(GameOverFlickerRoutine());
  }

  IEnumerator GameOverFlickerRoutine()
  {
    while (true)
    {
      _gameOverText.text = "GAME OVER";
      yield return new WaitForSeconds(0.5f);
      _gameOverText.text = "";
      yield return new WaitForSeconds(0.5f);
    }
  }

  public void ResumePlay()
  {
    GameManager gm = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    gm.ResumeGame();
  }

  public void BackToMainMenu()
  {
    SceneManager.LoadScene("Main_Menu");
    Time.timeScale = 1f;
  }
}
