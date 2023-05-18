using System.Collections.Generic;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    public List<GameObject> prefabTiles; // Assign your 3 prefab tiles in the inspector
    public int numberOfTiles; // Number of tiles to keep in the scene
    public float tileLength; // Length of a single tile
    public float safetyDistance; // Additional distance to keep a tile before destroying

    private Transform playerTransform;
    private Queue<GameObject> activeTiles;
    private float spawnZ;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new Queue<GameObject>();
        spawnZ = gameObject.transform.position.z;

        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - tileLength - safetyDistance > (spawnZ - numberOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(prefabTiles[Random.Range(0, prefabTiles.Count)], Vector3.forward * spawnZ, Quaternion.identity);
        spawnZ += tileLength;
        activeTiles.Enqueue(tile);
    }

    void DeleteTile()
    {
        Destroy(activeTiles.Dequeue());
    }
}
