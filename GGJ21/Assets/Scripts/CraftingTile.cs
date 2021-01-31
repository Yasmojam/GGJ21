using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CraftingTile : MonoBehaviour
{
    public string itemToCraft; // Raft, Boat, Bridge
    public GameObject craftPrompt;
    public GameObject canvas;

    public GameObject recipeResult;

    private GameObject promptInstance;
    private Inventory inventory;
    private Slot slot;

    Dictionary<string, int> raftRecipe = new Dictionary<string, int>();
    Dictionary<string, int> boatRecipe = new Dictionary<string, int>(); 
    Dictionary<string, int> bridgeRecipe = new Dictionary<string, int>(); 

    string[] keysList = null;
    Dictionary<string, int> promptRecipe = null;

    private bool withinCraftTile = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        raftRecipe.Add("Dark Wood", 5);

        bridgeRecipe.Add("Dark Wood", 2);
        bridgeRecipe.Add("Stone", 2);

        boatRecipe.Add("Light Wood", 15);
        boatRecipe.Add("Stone", 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (withinCraftTile){
            // Check for items in inventory
            if (HasRecipeItems(promptRecipe, keysList)){
                promptInstance.transform.GetChild(0).GetComponent<CanvasGroup>().alpha = 1f;
                if (Input.GetButton("Action"))
                {
                    Debug.Log("Try to get rid of shit");
                    List<Slot> slotsList = FindSlotsWithRecipeItems(keysList);
                    Queue<Slot> slotQueue = new Queue<Slot>(slotsList);
                    while (slotQueue.Count > 0) {
                        Slot slot = slotQueue.Dequeue();
                        slot.RemoveItemsFromSlot(promptRecipe[slot.GetItemType()]);
                        if (slot.count < 1){
                            Destroy(slot.gameObject.transform.GetChild(1).gameObject); // line is cursed
                        }
                    }
                    Destroy(this.GetComponent<PolygonCollider2D>()); // Remove collider
                    recipeResult.gameObject.GetComponent<TilemapRenderer>().enabled = !recipeResult.gameObject.GetComponent<TilemapRenderer>().enabled;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Triggered crafting");
            withinCraftTile = true;
            promptInstance = Instantiate(craftPrompt, canvas.transform);
            promptInstance.transform.GetChild(1).GetComponent<Text>().text = itemToCraft;

            // Asign important recipe
        
            switch (itemToCraft)
            {
                case "Raft":
                    promptRecipe = raftRecipe;
                    keysList = promptRecipe.Keys.ToArray();
                    break;
                case "Boat":
                    promptRecipe = boatRecipe;
                    keysList = promptRecipe.Keys.ToArray();
                    break;
                case "Bridge":
                    promptRecipe = bridgeRecipe;
                    keysList = promptRecipe.Keys.ToArray();
                    break;
            }

            // Name recipes and quantities
            if (keysList != null) { 
            for (int i = 0; i < keysList.Count(); i++)
            {
                // Item label
                promptInstance.transform.GetChild(i+2).GetComponent<Text>().text = keysList[i];
                // Item quantity
                promptInstance.transform.GetChild(i+4).GetComponent<Text>().text = "x " + promptRecipe[keysList[i]];

                }
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision){
        
    }


    private bool HasRecipeItems(Dictionary<string, int> promptRecipe, string[] keysList)
    {
        int entriesSufficient = 0;
        // Check each slot
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            // Check each entry in recipe
            for (int j = 0; j < keysList.Count(); j++)
            {
                slot = inventory.slots[i].GetComponent<Slot>();
                if (slot.GetItemType() == keysList[j] && slot.count >= promptRecipe[keysList[j]])
                {
                    entriesSufficient++;
                }
            }
        }

        // Condition for crafting satisfied
        if (entriesSufficient == keysList.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private List<Slot> FindSlotsWithRecipeItems(string[] keysList){
        List<Slot> slotsList = new List<Slot>();
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            Slot slot = inventory.slots[i].GetComponent<Slot>();
            for (int j = 0; j < keysList.Count(); j++)
            {
                if (slot.GetItemType() == keysList[j])
                {
                    slotsList.Add(slot);
                }
            }
        }
        return slotsList;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit crafting");
        withinCraftTile = false;
        if (promptInstance != null){
            Destroy(promptInstance);
        }
    }
}
