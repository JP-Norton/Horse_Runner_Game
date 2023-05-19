using System.Collections.Generic;
using UnityEngine;

public class Tile_Manager : MonoBehaviour
{
    public GameObject firstTilePrefab; // The first tile to spawn
    public List<GameObject> prefabTiles; // Assign your random prefab tiles in the inspector
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

        // Spawn the first tile
        SpawnTile(firstTilePrefab);

        // Then spawn the random tiles
        for (int i = 1; i < numberOfTiles; i++)
        {
            SpawnRandomTile();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - tileLength - safetyDistance > (spawnZ - numberOfTiles * tileLength))
        {
            SpawnRandomTile();
            DeleteTile();
        }
    }

    void SpawnTile(GameObject tilePrefab)
    {
        GameObject tile = Instantiate(tilePrefab, Vector3.forward * spawnZ, Quaternion.identity);
        spawnZ += tileLength;
        activeTiles.Enqueue(tile);
    }

    void SpawnRandomTile()
    {
        GameObject randomTile = prefabTiles[Random.Range(0, prefabTiles.Count)];
        SpawnTile(randomTile);
    }

    void DeleteTile()
    {
        Destroy(activeTiles.Dequeue());
    }
}
