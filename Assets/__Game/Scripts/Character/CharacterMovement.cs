using UnityEngine;

namespace CubeQuad
{
  public class CharacterMovement : MonoBehaviour
  {
    [field: SerializeField] public float MovementSpeed { get; private set; }
  }
}