using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
<<<<<<< HEAD
    private Slot slot;
    public GameObject itemInSlot; // Axe, Dark Wood, Light Wood, Stone
=======
    private Slots slot;
    public GameObject item;
    public AudioSource pickupSound;
>>>>>>> b394b7f061d47dfafe52d71c281fb3515a5062cb

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    // Collision is other object
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                slot = inventory.slots[i].GetComponent<Slot>();
                if (slot.GetItemType() == null)
                {
<<<<<<< HEAD
                    // ITEM CAN BE ADDED TO INVENTORY SO MAKE THIS SLOT FULL
                    Debug.Log("null to item");
                    slot.SetItemType(itemInSlot.name);
                    Instantiate(itemInSlot, inventory.slots[i].transform, false); // graphic will spawn in the middle of inventory slot graphic (false because not world space)
                    slot.AddItem(); // adds to count 
                    Destroy(gameObject);
                    break;
                }
                if (slot.GetItemType() == itemInSlot.name)
                {
                    Debug.Log("item already there");
                    slot.AddItem(); // adds to count 
                    Destroy(gameObject);
                    break;
=======
                    slot = inventory.slots[i].GetComponent<Slots>();
                    if (slot.GetItemType() == null)
                    {
                        // ITEM CAN BE ADDED TO INVENTORY SO MAKE THIS SLOT FULL
                        Debug.Log("null to item");
                        slot.SetItem(item.name);
                        Instantiate(item, inventory.slots[i].transform, false); // graphic will spawn in the middle of inventory slot graphic (false because not world space)
                        slot.AddItem(); // adds to count
                        pickupSound.Play();
                        Destroy(gameObject);
                        break;
                    }
                    if (slot.GetItemType() == item.name)
                    {
                        Debug.Log("item already there");
                        Instantiate(item, inventory.slots[i].transform, false); // graphic will spawn in the middle of inventory slot graphic (false because not world space)
                        slot.AddItem(); // adds to count 
                        pickupSound.Play();
                        Destroy(gameObject);
                        break;
                    }

>>>>>>> b394b7f061d47dfafe52d71c281fb3515a5062cb
                }

            }
        }
       
    }
}
