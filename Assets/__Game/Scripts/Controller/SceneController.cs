using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubeQuad
{
  public class SceneController : MonoBehaviour
  {
    public void RestartScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}