using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public Transform target; //This is for the transform(position) of the target which is the player
    public Vector2 offset = new Vector2(0f, 0f);
    public float smoothSpeed = 5;
    // Start is called before the first frame update


    //Using LateUpdate(), we ensure the camera moves after the player moves,
    //making the camera movement smoother and preventing any jittering.
    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(
              target.position.x + offset.x,
              target.position.y + offset.y,
              transform.position.z); // Keep the camera's z position fixed (e.g., -10)

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

    }
}
