using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool started;
    public FloatVariable playerSpeed;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        if(!started && Input.GetKey(KeyCode.Space)) {
            started = true; // start game
        }
        else if(started && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.right * playerSpeed.value; // if started and not holding space, go
        }
        else {
            rb.velocity = Vector2.zero; // if started and holding space, stop
        }
        if(transform.position.x > 8) { 
            ResetGame(); // off right of screen
        }
    }

    public void ResetGame()
    {
        started = false; // make player press and release space again
        transform.position = new Vector3(-6, -2, 0); // reset to starting position
    }
}