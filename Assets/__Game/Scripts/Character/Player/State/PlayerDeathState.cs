using UnityEngine;
using System.Collections;

namespace CubeQuad
{
  public class PlayerDeathState : State
  {
    public PlayerDeathState(PlayerController playerController)
    {
      _playerController = playerController;
      _playerHandler = _playerController.PlayerHandler;
      _playerMovement = _playerController.PlayerMovement;
      _playerFollowerHandler = _playerController.PlayerFollowerHandler;
    }

    private PlayerController _playerController;
    private PlayerHandler _playerHandler;
    private PlayerMovement _playerMovement;
    private PlayerFollowerHandler _playerFollowerHandler;

    public override void Enter()
    {
      _playerFollowerHandler.SetFollowerSpeed(0);
      _playerController.CharacterAnimation.DeathAnim();
      _playerController.StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
      yield return new WaitForSeconds(
        _playerController.CharacterAnimation.GetCurrentAnimationLength());

      DoSomethingAfterAnimation();
    }

    private void DoSomethingAfterAnimation()
    {
      Object.Instantiate(_playerHandler.DeathVFXObj,
        _playerController.transform.position, Quaternion.identity);

      _playerMovement.Model.gameObject.SetActive(false);
    }
  }
}