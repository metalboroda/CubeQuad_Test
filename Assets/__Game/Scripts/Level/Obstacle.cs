using UnityEngine;

namespace CubeQuad
{
  [SelectionBase]
  public class Obstacle : MonoBehaviour
  {
    [field: SerializeField] public ObstacleEnum ObstacleEnum { get; private set; }

    [Header("")]
    [SerializeField] private int _power = 100;

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(_power);
      }
    }
  }
}