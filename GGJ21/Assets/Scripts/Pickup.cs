using UnityEngine;
using UnityEngine.Audio;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    private Slot slot;
    public GameObject itemInSlot; // Axe, Dark Wood, Light Wood, Stone
    AudioSource pickupSound;
    private bool destroyed = false;
    float yPos;
    float offset;
    float bobIntensity = .02f;

    // Start is called before the first frame update
    void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pickupSound = GetComponent<AudioSource>();
        offset = Random.Range(0f, 360f);
        yPos = transform.position.y;
    }

    private void FixedUpdate() {

        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, yPos + Mathf.Cos(4 * (Time.time + offset)) * bobIntensity, pos.z);
    }



    // Collision is other object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyed) {
            return;
        }
       
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                slot = inventory.slots[i].GetComponent<Slot>();
                if (slot.GetItemType() == null)
                {
                    // ITEM CAN BE ADDED TO INVENTORY SO MAKE THIS SLOT FULL
                    Debug.Log("null to item");
                    slot.SetItemType(itemInSlot.name);
                    Instantiate(itemInSlot, inventory.slots[i].transform, false); // graphic will spawn in the middle of inventory slot graphic (false because not world space)
                    slot.AddItem(); // adds to count 
                    pickupSound.Play();
                    destroyed = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(gameObject, 1f);
                    break;
                }
                if (slot.GetItemType() == itemInSlot.name)
                {
                    Debug.Log("item already there");
                    slot.AddItem(); // adds to count 
                    pickupSound.Play();
                    destroyed = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(gameObject, 1f);
                    break;
                }

            }
        }
       
    }
}