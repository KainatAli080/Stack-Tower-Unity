using System.Threading;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    // This script will handle the block spawning 
    // (separating block movement and drop logic)

    public GameObject movingBlockPrefab;
    public Transform spawnPoint;        // where the first block will spawn
    private GameObject currentBlock;    // reference to the previous block to know when to spawn next block
    private Transform lastBlock;        // the block we just placed
    private static float count = 0;

    private void Start()
    {
        SpawnBlock(spawnPoint.position);
    }

    public void SpawnBlock(Vector3 spawnPos)
    {
        currentBlock = Instantiate(movingBlockPrefab, spawnPos, Quaternion.identity);
        lastBlock = currentBlock.transform;

        // Giving the current block a reference to the block manager so it can notify us when it falls
        currentBlock.GetComponent<BlockDropper>().blockManager = this;
    }

    public void onBlockLanded()
    {
        //count += 0.5f;
        //Debug.Log("Count Value: " + count);
        //// Spawning the next block just above the last placed one
        //// Vector3 nextPos = lastBlock.transform.position + Vector3.up * 1f; // moving one block up to allow the camera movement follow
        //Vector3 pointToMoveUp;
        //pointToMoveUp.x = 0;
        //pointToMoveUp.y = count;
        //pointToMoveUp.z = 0;

        // Move spawn point up by exactly 1 unit each time
        //Vector3 pointToMoveUp = new Vector3(0, 1f, 0);
        //spawnPoint.position += pointToMoveUp;

        // Get the y position of the last placed block
        float lastY = lastBlock.position.y;

        // Move spawn point exactly 1 unit above last block
        spawnPoint.position = new Vector3(
            spawnPoint.position.x,
            lastY + (5f * 0.6f),
            spawnPoint.position.z
        );

        SpawnBlock(spawnPoint.position);
        //Vector3 nextPos = spawnPoint.position + Vector3.up + pointToMoveUp; // moving one block up to allow the camera movement follow
        //spawnPoint.position = spawnPoint.position + pointToMoveUp;
        //SpawnBlock(spawnPoint.position);
    }
}
