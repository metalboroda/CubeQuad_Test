using UnityEngine;
using Zenject;

namespace CubeQuad
{
  public class PlayerController : MonoBehaviour
  {
    [field: SerializeField] public PlayerHandler PlayerHandler { get; private set; }
    [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
    [field: SerializeField] public PlayerFollowerHandler PlayerFollowerHandler { get; private set; }
    [field: SerializeField] public CharacterAnimation CharacterAnimation { get; private set; }
    [field: SerializeField] public PlayerCameraHandler PlayerCameraHandler { get; private set; }

    public StateMachine StateMachine { get; private set; } = new();

    [Inject] public InputManager InputManager { get; private set; }

    [Inject] public GameController GameController { get; private set; }

    private void Awake()
    {
      StateMachine.Init(new PlayerIdleState(this));

      GameController.StateChanged += (state) =>
      {
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
      GameController.StateChanged -= (state) => { };
    }
  }
}