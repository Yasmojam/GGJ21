using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVelocity : MonoBehaviour
{
    int framesToMove = 80;

	Rigidbody2D rigidbody;

    Vector2 targetDestination;
    Vector2 startPosition;
    int framesRemaining = 0;

    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = SnapToGrid(transform.position);
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
                CancelMove();
            }
            startPosition = SnapToGrid(transform.position);
            moving = false;
        } else {
            rigidbody.velocity = Vector2.zero;
            rigidbody.MovePosition(startPosition);
        }
    }

    void CancelMove() {
        rigidbody.MovePosition(startPosition);
        framesRemaining = 0;
        moving = false;
        rigidbody.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D hit) {
        if (!hit.gameObject.CompareTag("Player")) {
            CancelMove();
        }
    }

    Vector2 SnapToGrid(Vector2 v) {
        Vector2 snapped = new Vector2(Mathf.Round(v.x * 2) / 2, Mathf.Round(v.y * 4) / 4);
        return snapped + new Vector2(0, (1f - transform.localScale.y) / 4);
    }

    public void Move(Vector2 blockMovement) {
        if (moving)
            return;

        startPosition = transform.position;
        targetDestination = new Vector2(transform.position.x, transform.position.y) + blockMovement;

        targetDestination = SnapToGrid(targetDestination);

        Debug.Log(targetDestination);
        moving = true;
        framesRemaining = framesToMove;
    }
}
