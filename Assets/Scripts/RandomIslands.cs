using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomIslands : MonoBehaviour
{

    public GameObject islandPrefab;
    public Vector2 spawnRangeX = new Vector2(-15f, 5f);
    public float islandSpeed = 1f;
    public int numberOfIslands = 10;
    public float islands;
    public float stopYPosition;
    private List<Transform> islandsList = new List<Transform>();


    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        SpawnIslands();
        StartCoroutine(MovingIslands());
    }

    void SpawnIslands()
    {
        for (int i = 0; i < numberOfIslands; i++)
        {
            Transform newIsland = Instantiate(islandPrefab, GetRandomSpawnPosition(), Quaternion.identity).transform;
            IslandMovement islandMovementComponent = newIsland.gameObject.AddComponent<IslandMovement>();
            islandsList.Add(newIsland);
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Transform island in islandsList)
        {
            if (island.position.y <= stopYPosition)
            {
                IslandMovement islandMovement = island.GetComponent<IslandMovement>();
                if (islandMovement != null)
                {
                    islandMovement.StopMovement();
                }
            }
        }
    }

    // void CheckPlayerInteraction()
    // {

    // }

    IEnumerator MovingIslands()
    {

        done = false;

        float[] islandsLimits = new float[islandsList.Count];
        for (int i = 0; i < islandsList.Count; i++) {
            islandsLimits[i] = Random.Range(5f, 20f);
        }

        while (!done)
        {
            done = true;
            int i = 0;
            foreach (Transform island in islandsList)
            {
                if (island.position.y <= islandsLimits[i])
                {
                    island.Translate(Vector3.up * islandSpeed * Time.deltaTime);
                    done = false;
                }
                i++;
            }
            yield return null;

        }





        // while (true)
        // {
        //      Vector3 spawnPosition = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), 0f, 0f);
        //  GameObject newIsland = Instantiate(islandPrefab, spawnPosition, Quaternion.identity);

        // while (newIsland.transform.position.y < 10f) // Assuming islands move up to y = 10
        // {
        //     newIsland.transform.Translate(Vector3.up * islandSpeed * Time.deltaTime);
        //     yield return null;
        // }


        yield return new WaitForSeconds(Random.Range(1f, 5f)); // Wait before spawning the next island
        // }
    }

    Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), 0f, Random.Range(spawnRangeX.x, spawnRangeX.y));
    }
}
