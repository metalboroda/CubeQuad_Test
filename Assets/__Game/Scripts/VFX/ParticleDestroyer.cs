using UnityEngine;

namespace CubeQuad
{
  public class ParticleDestroyer : MonoBehaviour
  {
    [SerializeField] private bool _destroyInTheEnd;

    private ParticleSystem _particleSystem;

    private void Awake()
    {
      _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
      if (_destroyInTheEnd == true)
      {
        Destroy(gameObject, _particleSystem.main.duration + 0.01f);
      }
    }
  }
}