using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float pushForce = 0.01f;
    public float pullForce = 0.01f;
    public bool inPush = false;
    public bool inPull = false;
    Rigidbody2D playerRigidBody;

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
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1); // prevent diagonal movement being faster
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        playerRigidBody.MovePosition(newPos);
    }  

    void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.tag == "BlockPuzzle") {
            Debug.Log("Collision!");
        }
    }

    void OnCollisionStay2D(Collision2D hit) {
        if(hit.gameObject.tag == "BlockPuzzle") {
            Vector2 currentPos = playerRigidBody.position;
            Vector2 hitCurrentPos = hit.rigidbody.position;
            Debug.Log("Input hor " + Input.GetAxis("Horizontal"));
            Debug.Log("Input ver " + Input.GetAxis("Vertical"));
            Debug.Log("Push " + inPush);
            Debug.Log("Pull " + inPull);

            if(inPush) {
                // On left and push
                if(Input.GetAxis("Horizontal") > 0) {
                    hit.rigidbody.MovePosition(-hitCurrentPos*pushForce);
                }
                // On right and push
                if(Input.GetAxis("Horizontal") <= 0) {
                    hit.rigidbody.MovePosition(-hitCurrentPos*pushForce);
                }
            }
            else if(inPull) {
                // On right and pull
                if(Input.GetAxis("Horizontal") > 0) {
                    hit.rigidbody.MovePosition(-hitCurrentPos*pullForce);
                }
                // On left and pull
                if(Input.GetAxis("Horizontal") <= 0) {
                    hit.rigidbody.MovePosition(-hitCurrentPos*pullForce);
                }
            }
            else if(Input.GetButton("Push")) {
                inPull = false;
                inPush = true;
            }
            else if(Input.GetButton("Pull")) {
                inPush = false;
                inPull = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D hit) {
        inPush = false;
        inPull = false;
    }

}
