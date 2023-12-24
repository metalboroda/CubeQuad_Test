using UnityEngine;

namespace CubeQuad
{
  public class Setup : MonoBehaviour
  {
    private void Awake()
    {
      QualitySettings.vSyncCount = 1;
      Application.targetFrameRate = 120;
    }
  }
}