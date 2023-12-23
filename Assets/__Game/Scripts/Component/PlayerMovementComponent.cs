using DG.Tweening;
using UnityEngine;

namespace CubeQuad
{
  public class PlayerMovementComponent
  {
    private Tweener _rotTween;

    public void TouchSideMovement(float axis, float speed, float limitX, Transform transform, Transform rotateTarget)
    {
      if (Input.touchCount > 0)
      {
        // Movement
        float moveX = axis * speed;
        float newX = transform.localPosition.x + moveX * Time.deltaTime;

        newX = Mathf.Clamp(newX, -limitX, limitX);
        transform.localPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);

        if (transform.localPosition.x == -limitX || transform.localPosition.x == limitX)
        {
          DOTween.Kill(_rotTween);

          rotateTarget.DOLocalRotate(Vector3.zero, 0.1f);
        }
        else
        {
          _rotTween = rotateTarget.DOLocalRotate(new Vector3(0, moveX * 3f, 0), 0.2f);
        }
      }
      else if (Input.touchCount == 0)
      {
        rotateTarget.DOLocalRotate(Vector3.zero, 0.1f);
      }
    }
  }
}