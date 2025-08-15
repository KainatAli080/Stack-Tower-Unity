using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // Our SpawnPoint
    private float lastTargetY;

    public float smoothingSpeed = 5f;
    public Vector3 offset; // How much to move

    private void Start()
    {
        if (target != null)
            lastTargetY = target.position.y + offset.y;
    }

    private void LateUpdate()
    {
        // LateUpdate is for camera movement

        // Only moving camera if spawnpoint has moved
        if (target == null)
            return;

        if(target.position.y > lastTargetY)
        {
            Vector3 desiredPos = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothingSpeed * Time.deltaTime);

            transform.position = smoothedPos;
            lastTargetY = target.position.y;
        }

    }

}
