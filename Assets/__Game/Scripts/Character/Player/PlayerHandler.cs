using UnityEngine;

namespace CubeQuad
{
  public class PlayerHandler : CharacterHandler
  {
    [SerializeField] private PlayerController _playerController;

    public override void Damage(int damage)
    {
      Health -= damage;

      if (Health <= 0)
      {
        Health = 0;

        _playerController.StateMachine.ChangeState(new PlayerDeathState(_playerController));
      }
    }
  }
}