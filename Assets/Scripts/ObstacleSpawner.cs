using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float delay, batchDelay = 2f; // delay is time until next drop, batchDelay is time after batch is dropped
    private int remaining, batchSize = 7; // remaining is how many are left in current batch, batchSize is how many are dropped in a batch

    private void Start() {
        remaining = batchSize;
        delay += Random.Range(0.0f, 1f); // randomize start times by a bit to offset spawners
    }

    private void FixedUpdate()
    {
        delay -= Time.deltaTime; // decrease delay timer
        if(delay <= 0) {
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity); // spawn obstacle
            remaining--; // decrease batch counter
            if(remaining == 0) { // if there are no obstacles remaining in the current batch
                remaining = batchSize; // reset size for next batch
                delay = batchDelay; // start delay between batches
            }
            else { // there is another obstacle in the current batch
                delay = Random.Range(0.1f, 0.2f); // wait a random, short time
            }
        }
    }
}