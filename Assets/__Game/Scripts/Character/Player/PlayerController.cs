using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace CubeQuad
{
  public class PlayerController : MonoBehaviour
  {
    [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
    [field: SerializeField] public PlayerFollowerHandler PlayerFollowerHandler { get; private set; }
    [field: SerializeField] public CharacterAnimation CharacterAnimation { get; private set; }
    [field: SerializeField] public PlayerCameraHandler PlayerCameraHandler { get; private set; }

    public StateMachine StateMachine { get; private set; } = new();

    [Inject] public InputManager InputManager { get; private set; }

    [Inject] private GameController _gameController;

    private void Awake()
    {
      _gameController.StateChanged += (state) =>
      {
        if (state == GameStateEnum.Start)
        {
          StateMachine.Init(new PlayerIdleState(this));
        }

        if (state == GameStateEnum.Game)
        {
          StateMachine.ChangeState(new PlayerMovementState(this));
        }
      };
    }

    private void Update()
    {
      StateMachine.CurrentState.Update();
    }

    private void OnDestroy()
    {
      _gameController.StateChanged -= (state) => { };
    }

    private void ToWinState()
    {
      StateMachine.ChangeState(new PlayerWinState(this));
    }
  }
}