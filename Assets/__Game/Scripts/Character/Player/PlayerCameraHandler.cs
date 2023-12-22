using System.Collections.Generic;
using UnityEngine;

namespace CubeQuad
{
  public class PlayerCameraHandler : MonoBehaviour
  {
    [SerializeField] private List<GameObject> _cameras = new();

    [field: Header("")]
    [field: SerializeField] public GameObject MainCamera { get; private set; }
    [field: SerializeField] public GameObject FrontCamera { get; private set; }

    public void SwitchCamera(GameObject cameraToEnable)
    {
      foreach (var screen in _cameras)
      {
        if (screen == cameraToEnable)
        {
          screen.SetActive(true);
        }
        else
        {
          screen.SetActive(false);
        }
      }
    }
  }
}