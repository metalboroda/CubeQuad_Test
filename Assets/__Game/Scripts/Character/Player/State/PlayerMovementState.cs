namespace CubeQuad
{
  public class PlayerMovementState : State
  {
    public PlayerMovementState(PlayerController playerController)
    {
      _playerController = playerController;
      _playerMovement = _playerController.PlayerMovement;
    }

    private PlayerMovementComponent _playerMovementComponent = new();

    private PlayerController _playerController;
    private PlayerMovement _playerMovement;

    public override void Enter()
    {
      _playerController.PlayerFollowerHandler.SetFollowerSpeed(_playerMovement.MovementSpeed);
      _playerController.CharacterAnimation.RunAnim();
    }

    public override void Update()
    {
      _playerMovementComponent.SideMovement(_playerMovement.SideMovementSpeed,
        _playerController.InputManager.Joystick.Horizontal, _playerMovement.MovementLimitX,
        _playerController.transform, _playerMovement.Model.transform);
    }
  }
}