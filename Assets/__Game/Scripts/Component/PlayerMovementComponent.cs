using DG.Tweening;
using UnityEngine;

namespace CubeQuad
{
  public class PlayerMovementComponent
  {
    public void TouchSideMovement(float axis, float speed, float limitX, Transform transform, Transform rotateTarget)
    {
      if (Input.touchCount > 0)
      {
        // Movement
        float moveX = axis * speed;
        float newX = transform.localPosition.x + moveX * Time.deltaTime;

        newX = Mathf.Clamp(newX, -limitX, limitX);
        transform.localPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);

        // Rotation
        rotateTarget.DOLocalRotate(new Vector3(0, moveX * 3f, 0), 0.2f);
      }
    }
  }
}