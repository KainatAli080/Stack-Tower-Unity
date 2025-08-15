using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    public BlockManager blockManager;   // our main Block Manager
    private Rigidbody rb;
    private MovingBlock movingBlockScript;
    private bool hasLanded = false;

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
        if(!hasLanded && Input.GetMouseButtonDown(0))
        {
            Drop();
        }
    }

    private void Drop()
    {
        rb.isKinematic = false;
        movingBlockScript.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TowerBase") && !hasLanded)
        {
            hasLanded = true;
            //Destroy(rb);
            rb.isKinematic = true;  // meaning no fall because physics untrue
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            this.gameObject.tag = "TowerBase";
            blockManager.onBlockLanded(); // Tell manager to spawn next block

            this.enabled = false;
        }
    }
}
