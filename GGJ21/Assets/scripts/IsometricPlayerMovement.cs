using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{

    enum BlockDirection {
        Up,
        Down,
        Left,
        Right
    }

    float movementSpeed = 20f;
    float playerMovementSpeed = 19f;
    bool canMove = false;
    Vector2 verticalMove = new Vector2(2f, 1f);
    Vector2 horizontalMove = new Vector2(2f, -1f);
    Rigidbody2D playerRigidBody;
    Vector2 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = playerRigidBody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        inputVector = (verticalMove * verticalInput) + (horizontalMove * horizontalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1); // prevent diagonal movement being faster
        Vector2 movement = inputVector * playerMovementSpeed;
        playerRigidBody.velocity = movement * Time.fixedDeltaTime;

        canMove = Input.GetButton("Action");
    }

    void OnCollisionStay2D(Collision2D hit) {
        if(hit.gameObject.tag == "BlockPuzzle") {

            Vector2 currentPos = playerRigidBody.position;
            Vector2 hitCurrentPos = hit.rigidbody.position;
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");
            Vector2 distance = currentPos - hitCurrentPos;

            Debug.Log("Can move " + canMove);
            Debug.Log("Distance " + distance);

            // +x, -y right
            // +x, +y above
            // -x, +y left
            // -x, -y below

            if(canMove) {
                // Figure out if player is on left or right of stone
                if(distance.x > 0 && distance.y < 0) {
                    // Right of stone

                    // Moving right
                    if(inputHorizontal > 0 && inputVertical == 0) {
                        MoveBlock(BlockDirection.Right, hit);
                    }
                    // Moving left
                    if(inputHorizontal < 0 && inputVertical == 0) {
                        MoveBlock(BlockDirection.Left, hit);
                    }
                }
                else if(distance.x > 0 && distance.y > 0) {
                    // Above stone

                    // Moving up
                    if(inputHorizontal == 0 && inputVertical > 0) {
                        MoveBlock(BlockDirection.Up, hit);
                    }
                    // Moving down
                    if(inputHorizontal == 0 && inputVertical < 0) {
                        MoveBlock(BlockDirection.Down, hit);
                    }
                }
                else if(distance.x < 0 && distance.y > 0) {
                    // Left of stone

                    // Moving right
                    if(inputHorizontal > 0 && inputVertical == 0) {
                        MoveBlock(BlockDirection.Right, hit);
                    }
                    // Moving left
                    if(inputHorizontal < 0 && inputVertical == 0) {
                        MoveBlock(BlockDirection.Left, hit);
                    }
                }
                else if(distance.x < 0 && distance.y < 0) {
                    // Above stone

                    // Moving up
                    if(inputHorizontal == 0 && inputVertical > 0) {
                        MoveBlock(BlockDirection.Up, hit);
                    }
                    // Moving down
                    if(inputHorizontal == 0 && inputVertical < 0) {
                        MoveBlock(BlockDirection.Down, hit);
                    }
                }
            }
        }
    }

    private void MoveBlock(BlockDirection direction, Collision2D hit) {
        Vector2 blockMovement;
        Vector2 blockInputVector = new Vector2(0, 0);
        switch(direction) {
            case BlockDirection.Up:
                blockInputVector = new Vector2(2f, 1f);
                break;
            case BlockDirection.Down:
                blockInputVector = new Vector2(-2f, -1f);
                break;
            case BlockDirection.Left:
                blockInputVector = new Vector2(-2f, 1f);
                break;
            case BlockDirection.Right:
                blockInputVector = new Vector2(2f, -1f);
                break;
            default:
                Debug.Log("No direction given");
                break;
        }
        blockInputVector = Vector2.ClampMagnitude(blockInputVector, 1); // prevent diagonal movement being faster
        blockMovement = blockInputVector * movementSpeed;
        BlockVelocity blockScript = hit.gameObject.GetComponent<BlockVelocity>();
        blockScript.Move(blockMovement);
    }

}
