using UnityEngine;

namespace CubeQuad
{
  public class CharacterAnimation : MonoBehaviour
  {
    [SerializeField] private CharacterAnimationSO _characterAnimationSO;

    [Header("")]
    [SerializeField] private float _crossfade = 0.2f;

    [Header("")]
    [SerializeField] private Animator _animator;

    public void IdleAnim()
    {
      _animator.CrossFadeInFixedTime(_characterAnimationSO.Idle, _crossfade);
    }

    public void RunAnim()
    {
      _animator.CrossFadeInFixedTime(_characterAnimationSO.Run, _crossfade);
    }

    public void RandDanceAnim()
    {
      _animator.CrossFadeInFixedTime(_characterAnimationSO.GetRandomDanceAnim(), _crossfade);
    }
  }
}