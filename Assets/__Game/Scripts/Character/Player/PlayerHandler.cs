using UnityEngine;

namespace CubeQuad
{
  public class PlayerHandler : CharacterHandler
  {
    [field: Header("")]
    [field: SerializeField] public GameObject DeathVFXObj { get; private set; }

    [Header("")]
    [SerializeField] private CapsuleCollider _capsuleCollider;

    [Header("")]
    [SerializeField] private PlayerController _playerController;

    public override void Damage(int damage)
    {
      Health -= damage;

      if (Health <= 0)
      {
        Health = 0;
        _capsuleCollider.enabled = false;

        _playerController.StateMachine.ChangeState(new PlayerDeathState(_playerController));
      }
    }
  }
}