using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePuzzleChecker : MonoBehaviour
{

	int triggeredCount;
	public int counterGoal = 7;
    bool rewardsGiven = false;
    public AudioSource audio;

    public List<GameObject> rewards;

    // Start is called before the first frame update
    void Start()
    {
        triggeredCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	if(triggeredCount == counterGoal && !rewardsGiven) {
            rewardsGiven = true;
    		Debug.Log("WIN");

            audio.Play();

            foreach (GameObject reward in rewards) {
                reward.SetActive(true);
            }
    	}
    }

    public void UpdateTriggerCounter(int i) {
    	triggeredCount = triggeredCount + i;
    	Debug.Log(triggeredCount);
    }
}
