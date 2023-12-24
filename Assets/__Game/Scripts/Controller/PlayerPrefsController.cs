using UnityEngine;

namespace CubeQuad
{
  public class PlayerPrefsController : MonoBehaviour
  {
    #region Level
    public int GetLevelIndex()
    {
      return PlayerPrefs.GetInt("LevelIndex");
    }

    public void SaveLevelIndex(int index)
    {
      PlayerPrefs.SetInt("LevelIndex", index);
    }
    #endregion
  }
}