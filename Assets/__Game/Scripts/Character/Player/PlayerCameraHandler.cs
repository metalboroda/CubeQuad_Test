using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace CubeQuad
{
  public class PlayerCameraHandler : MonoBehaviour
  {
    [field: SerializeField] public CinemachineVirtualCamera MainCamera { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera FrontCamera { get; private set; }

    private List<CinemachineVirtualCamera> _cameras = new();

    private void Awake()
    {
      InitializeCamerasList();
    }

    public void SwitchCamera(CinemachineVirtualCamera cameraToEnable)
    {
      foreach (var screen in _cameras)
      {
        if (screen == cameraToEnable)
        {
          screen.gameObject.SetActive(true);
        }
        else
        {
          screen.gameObject.SetActive(false);
        }
      }
    }

    private void InitializeCamerasList()
    {
      _cameras.Add(MainCamera);
      _cameras.Add(FrontCamera);
    }
  }
}