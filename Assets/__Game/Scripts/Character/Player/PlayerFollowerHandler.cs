using Dreamteck.Splines;
using System.Linq;
using UnityEngine;

namespace CubeQuad
{
  public class PlayerFollowerHandler : MonoBehaviour
  {
    [field: SerializeField] public SplineFollower SplineFollower { get; private set; }

    [Header("")]
    [SerializeField] private PlayerController _playerController;

    private SplineComputer SplineComputer;

    private void Awake()
    {
      SplineComputer = SplineFollower.spline;

      SplineFollower.onEndReached += EndReached;
    }

    private void OnDestroy()
    {
      SplineFollower.onEndReached -= EndReached;
    }

    public void SetFollowerSpeed(float speed)
    {
      SplineFollower.followSpeed = speed;
    }

    public Vector3 GetEndPointPosition()
    {
      return SplineComputer.GetPoints().Last().position;
    }

    private void EndReached(double obj)
    {
      _playerController.StateMachine.ChangeState(new PlayerWinState(_playerController));
      _playerController.GameController.ChangeState(GameStateEnum.Win);
    }
  }
}