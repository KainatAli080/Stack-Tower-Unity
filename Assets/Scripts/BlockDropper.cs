using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    private Rigidbody rb;
    private MovingBlock movingBlockScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // meaning no fall because physics untrue

        movingBlockScript = GetComponent<MovingBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            movingBlockScript.enabled = false;
        }
    }
}
