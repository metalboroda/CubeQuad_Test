using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace CubeQuad
{
  public class LevelController : MonoBehaviour
  {
    [SerializeField] private PlayerPrefsController _playerPrefsController;

    private string _address;
    private int _levelIndex;
    private GameObject _spawnedLevel;

    [Inject] private DiContainer _spawnContainer;

    private async void Start()
    {
      _levelIndex = _playerPrefsController.GetLevelIndex();

      SetAddressIndex(_levelIndex);

      await LoadLevel(_address);
    }

    public void RestartLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
      _levelIndex++;
      _playerPrefsController.SaveLevelIndex(_levelIndex);

      SetAddressIndex(_levelIndex);

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public async Task<GameObject> LoadLevel(string address)
    {
      var loadOperation = Addressables.LoadAssetAsync<GameObject>(address);
      await loadOperation.Task;

      if (loadOperation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
      {
        GameObject prefab = loadOperation.Result;
        _spawnedLevel = _spawnContainer.InstantiatePrefab(prefab);

        return _spawnedLevel;
      }
      else
      {
        Debug.Log($"No address: {address}");

        return null;
      }
    }

    private void SetAddressIndex(int index)
    {
      _address = $"Assets/__Game/Prefabs/Level/Level_{index}.prefab";
    }
  }
}