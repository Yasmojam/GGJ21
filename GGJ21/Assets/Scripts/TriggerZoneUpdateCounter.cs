using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneUpdateCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hit) {
    	if(hit.gameObject.tag == "BlockPuzzle") {
	    	ShapePuzzleChecker script = this.transform.parent.gameObject.GetComponent<ShapePuzzleChecker>();
	    	script.UpdateTriggerCounter(1);
    	}
    }

    void OnTriggerExit2D(Collider2D hit) {
    	if(hit.gameObject.tag == "BlockPuzzle") {
	    	ShapePuzzleChecker script = this.transform.parent.gameObject.GetComponent<ShapePuzzleChecker>();
	    	script.UpdateTriggerCounter(-1);
    	}
    }
}
