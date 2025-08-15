using UnityEngine;

public class BlockManager : MonoBehaviour
{
    // This script will handle the block spawning 
    // (separating block movement and drop logic)

    public GameObject movingBlockPrefab;
    public Transform spawnPoint;        // where the first block will spawn
    private GameObject currentBlock;    // reference to the previous block to know when to spawn next block
    private Transform lastBlock;        // the block we just placed

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
        // Spawning the next block just above the last placed one
        Vector3 nextPos = lastBlock.transform.position + Vector3.up * 5f; // moving one block up to allow the camera movement follow
        SpawnBlock(nextPos);
    }
}
