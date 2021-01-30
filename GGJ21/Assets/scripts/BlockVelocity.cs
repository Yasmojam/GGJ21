using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVelocity : MonoBehaviour
{

	Rigidbody2D rigidbody;
	bool movedThisFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
    	if(!movedThisFrame) {
    		rigidbody.velocity = new Vector2(0, 0);
    	}
    	movedThisFrame = false;
    }

    public void Move(Vector2 blockMovement) {
        rigidbody.velocity = blockMovement * Time.fixedDeltaTime;
        movedThisFrame = true;
    }
}
