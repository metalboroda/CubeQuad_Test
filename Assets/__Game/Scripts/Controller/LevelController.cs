using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace CubeQuad
{
  public class LevelController : MonoBehaviour
  {
    [SerializeField] private string _address;

    [Inject] private DiContainer _spawnContainer;

    private void Start()
    {

    }

    public void RestartLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public async Task<GameObject> LoadLevel(string address)
    {
      var loadOperation = Addressables.LoadAssetAsync<GameObject>(address);
      await loadOperation.Task;

      if (loadOperation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
      {
        GameObject prefab = loadOperation.Result;
        GameObject instance = _spawnContainer.InstantiatePrefab(prefab);

        return instance;
      }
      else
      {
        Debug.Log($"No address: {address}");

        return null;
      }
    }
  }
}