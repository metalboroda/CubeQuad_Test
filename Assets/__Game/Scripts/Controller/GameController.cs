using System;
using UnityEngine;

namespace CubeQuad
{
  public class GameController : MonoBehaviour
  {
    public event Action<GameStateEnum> StateChanged;

    [field: SerializeField] public GameStateEnum GameState { get; private set; }

    private GameStateEnum _currentState;

    private void Start()
    {
      ChangeState(GameStateEnum.Start);
    }

    public void ChangeState(GameStateEnum newState)
    {
      if (_currentState != newState)
      {
        GameState = newState;
        _currentState = GameState;

        StateChanged?.Invoke(GameState);
      }
    }
  }
}