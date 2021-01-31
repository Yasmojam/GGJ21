using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePuzzleChecker : MonoBehaviour
{

	int triggeredCount;
	int counterGoal = 7;

    // Start is called before the first frame update
    void Start()
    {
        triggeredCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	if(triggeredCount == counterGoal) {
    		// TODO: Trigger item reward script method here
    		Debug.Log("WIN");
    	}
    }

    public void UpdateTriggerCounter(int i) {
    	triggeredCount = triggeredCount + i;
    	Debug.Log(triggeredCount);
    }
}
