using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubeQuad
{
  public class UIManager : MonoBehaviour
  {
    [Header("Start Screen")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _startBtn;

    [Header("Game Screen")]
    [SerializeField] private GameObject _gameScreen;

    [Header("Lose Screen")]
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Button _loseRestartBtn;

    [Header("Win Screen")]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Button _winRestartBtn;

    [Header("")]
    [SerializeField] private GameController _gameController;
    [SerializeField] private LevelController _sceneController;

    private List<GameObject> _screens = new();

    private void Awake()
    {
      SubscribeButtons();
      InitializeScreensList();

      _gameController.StateChanged += LoseScreen;
      _gameController.StateChanged += WinScreen;
    }

    private void OnDestroy()
    {
      _gameController.StateChanged -= LoseScreen;
      _gameController.StateChanged -= WinScreen;
    }

    private void SubscribeButtons()
    {
      _startBtn.onClick.AddListener(() =>
      {
        _gameController.ChangeState(GameStateEnum.Game);

        SwitchScreen(_gameScreen);
      });

      _loseRestartBtn.onClick.AddListener(() => { _sceneController.RestartLevel(); });

      _winRestartBtn.onClick.AddListener(() => { _sceneController.LoadNextLevel(); });
    }

    private void InitializeScreensList()
    {
      _screens.Add(_startScreen);
      _screens.Add(_gameScreen);
      _screens.Add(_loseScreen);
      _screens.Add(_winScreen);
    }

    private void LoseScreen(GameStateEnum gameState)
    {
      if (gameState == GameStateEnum.Lose)
      {
        StartCoroutine(DoLoseScreen());
      }
    }

    private IEnumerator DoLoseScreen()
    {
      yield return new WaitForSeconds(1.5f);

      SwitchScreen(_loseScreen);
    }

    private void WinScreen(GameStateEnum gameState)
    {
      if (gameState == GameStateEnum.Win)
      {
        StartCoroutine(DoWinScreen());
      }
    }

    private IEnumerator DoWinScreen()
    {
      yield return new WaitForSeconds(1.5f);

      SwitchScreen(_winScreen);
    }

    private void SwitchScreen(GameObject screenToEnable)
    {
      foreach (var screen in _screens)
      {
        if (screen == screenToEnable)
        {
          screen.SetActive(true);
        }
        else
        {
          screen.SetActive(false);
        }
      }
    }
  }
}