using UnityEngine;

namespace CubeQuad
{
  [SelectionBase]
  public class Obstacle : MonoBehaviour
  {
    [SerializeField] private int _power = 100;

    private void OnTriggerEnter(Collider other)
    {
      Debug.Log(other.name);

      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(_power);
      }
    }
  }
}