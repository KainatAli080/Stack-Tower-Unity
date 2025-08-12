using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveRange = 3f;
    private int direction = 1; // 1 for right, -1 for left
    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;       
    }

    // Update is called once per frame
    void Update()
    {
        // Moving left and right now
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * direction);
        // Checking bounds for direction Change
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveRange)
        {
            direction *= -1;
        }
    }
}
