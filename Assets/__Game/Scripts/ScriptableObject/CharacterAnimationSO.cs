using System.Collections.Generic;
using UnityEngine;

namespace CubeQuad
{
  [CreateAssetMenu(menuName = "CharacterAnimation")]
  public class CharacterAnimationSO : ScriptableObject
  {
    [field: SerializeField] public string Idle { get; private set; }
    [field: SerializeField] public string Run { get; private set; }
    [field: SerializeField] public List<string> Dances { get; private set; } = new();
    [field: SerializeField] public string Death { get; private set; }

    public string GetRandomDanceAnim()
    {
      int rand = Random.Range(0, Dances.Count);

      return Dances[rand];
    }
  }
}