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
        // If lands on previous block, continue game
        if (collision.gameObject.CompareTag("PrevBlock") && !hasLanded)
        {
            hasLanded = true;
            //Destroy(rb);
            rb.isKinematic = true;  // meaning no fall because physics untrue
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Updating tags 
            this.gameObject.tag = "PrevBlock";
            collision.gameObject.tag = "TowerBase";

            // Tell manager to spawn next block
            blockManager.onBlockLanded(); 

            // Disabling this script to stop checking collisions and updates
            this.enabled = false;
        }
        // else if falls on any block besides previous, game over
        else if(collision.gameObject.CompareTag("TowerBase") && !hasLanded)
        {
            // Game Over Logic
            Debug.Log("GAME OVER!");
        }
    }
}
