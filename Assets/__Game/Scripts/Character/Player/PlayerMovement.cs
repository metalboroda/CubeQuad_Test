using UnityEngine;

namespace CubeQuad
{
  public class PlayerMovement : CharacterMovement
  {
    [field: SerializeField] public float SideMovementSpeed { get; private set; }
    [field: SerializeField] public float MovementLimitX { get; private set; }
    [field: SerializeField] public GameObject Model { get; private set; }

    [Header("")]
    [SerializeField] private PlayerController _playerController;
  }
}