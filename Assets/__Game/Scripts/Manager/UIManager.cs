using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubeQuad
{
  public class UIManager : MonoBehaviour
  {
    [SerializeField] private List<GameObject> _screens = new();

    [Header("Start Screen")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _startBtn;

    [Header("Game Screen")]
    [SerializeField] private GameObject _gameScreen;

    [Header("")]
    [SerializeField] private GameController _gameController;

    private void Awake()
    {
      SubscribeButtons();
    }

    private void SubscribeButtons()
    {
      _startBtn.onClick.AddListener(() =>
      {
        _gameController.ChangeState(GameStateEnum.Game);

        SwitchScreen(_gameScreen);
      });
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