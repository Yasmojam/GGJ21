using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTile : MonoBehaviour
{
    public string itemToCraft;
    public GameObject craftPrompt;
    public GameObject canvas;
    private GameObject promptInstance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Triggered crafting");
            promptInstance = Instantiate(craftPrompt, canvas.transform);
            promptInstance.transform.GetChild(1).GetComponent<Text>().text = itemToCraft;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit crafting");
        Destroy(promptInstance);
    }
}
