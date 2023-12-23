using UnityEngine;

namespace CubeQuad
{
  public abstract class CharacterHandler : MonoBehaviour, IDamageable
  {
    [SerializeField] protected int Health = 100;

    public virtual void Damage(int damage) { }
  }
}