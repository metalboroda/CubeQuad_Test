using DG.Tweening;
using UnityEngine;

namespace CubeQuad
{
  public class PlayerWinState : State
  {
    public PlayerWinState(PlayerController playerController)
    {
      _playerController = playerController;
      _playerMovement = _playerController.PlayerMovement;
      _playerCameraHandler = _playerController.PlayerCameraHandler;
      _playerFollowerHandler = _playerController.PlayerFollowerHandler;
    }

    private PlayerController _playerController;
    private PlayerMovement _playerMovement;
    private PlayerCameraHandler _playerCameraHandler;
    private PlayerFollowerHandler _playerFollowerHandler;

    public override void Enter()
    {
      _playerCameraHandler.SwitchCamera(_playerCameraHandler.FrontCamera);
      _playerController.transform.DOLookAt(_playerController.transform.parent.position, 0.25f);
      _playerController.transform.DOMove(_playerController.transform.parent.position,
        _playerMovement.MovementSpeed).SetSpeedBased(true).OnComplete(() =>
        {
          _playerController.transform.DOLookAt(
            _playerFollowerHandler.GetEndPointPosition(), 0.25f);
          _playerController.CharacterAnimation.RandDanceAnim();
        });
    }
  }
}