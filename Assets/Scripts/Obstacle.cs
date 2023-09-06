using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update() {
        if(transform.position.y < -6) {
            Destroy(gameObject); // destroy obstacle if it already fell off screen
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
        if(player != null) {
            player.ResetGame(); // reset game if player is hit
        }
    }
}
