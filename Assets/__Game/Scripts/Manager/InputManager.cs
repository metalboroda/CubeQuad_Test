using UnityEngine;

namespace CubeQuad
{
  public class InputManager : MonoBehaviour
  {
    [field: SerializeField] public Joystick Joystick { get; private set; }
  }
}