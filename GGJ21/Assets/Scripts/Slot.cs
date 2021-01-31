using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public int count = 0;
    private TextMeshProUGUI countRender;
    public bool isFull;
    private string itemType = null;

    private void Start()
    {
        countRender = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }


    public void AddItem()
    {
        count++;
        // If more than one in slot make a count appear
        if (count > 1)
        {
            countRender.text = count.ToString();
        }
        else
        {
            countRender.text = "";
        }
    }

    public void SetItemType(string itemType)
    {
        this.itemType = itemType;
        Debug.Log(itemType);
    }


    public void RemoveItemsFromSlot(int numberToRemove)
    {
        if (numberToRemove <= count) {
            count -= numberToRemove;
            if (count < 2)
            {
               countRender.text = "";

                if (count < 1)
                {
                    this.itemType = null;
                }
            }
            else
            {
                countRender.text = count.ToString();
            }
            
        }
        
    }

    public string GetItemType()
    {
        return this.itemType;
    }

}
