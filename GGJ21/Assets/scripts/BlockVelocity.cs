using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVelocity : MonoBehaviour
{
    int framesToMove = 75;  // 1.5secs

	Rigidbody2D rigidbody;

    Vector2 targetDestination;
    Vector2 startPosition;
    int framesRemaining = 0;

    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate() {
        if (framesRemaining > 0) {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetDestination, 1f);

            Vector2 diff = newPosition - (Vector2)transform.position;

            if (diff.magnitude < 0.01) {
                rigidbody.MovePosition(targetDestination);
            } else {
                rigidbody.velocity = diff * 3;
            }
            framesRemaining -= 1;
        } else if (moving) {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetDestination, 10f);
            Vector2 diff = newPosition - (Vector2)transform.position;

            if (diff.magnitude < 0.05) {
                rigidbody.MovePosition(targetDestination);
            } else {
                rigidbody.MovePosition(startPosition);
            }

            moving = false;
        } else {
            rigidbody.velocity = Vector2.zero;
        }
    }

    public void Move(Vector2 blockMovement) {
        if (moving)
            return;

        startPosition = transform.position;
        targetDestination = new Vector2(transform.position.x, transform.position.y) + blockMovement;

        targetDestination = new Vector2(Mathf.Round(targetDestination.x * 2) / 2, Mathf.Round(targetDestination.y * 4) / 4);

        Debug.Log(targetDestination);
        moving = true;
        framesRemaining = framesToMove;
    }
}
