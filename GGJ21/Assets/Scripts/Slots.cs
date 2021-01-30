using System;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public int count = 0;
    private Text countRender;
    public bool isFull;
    private string itemType = null;

    private void Start()
    {
        countRender = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
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

    public void SetItem(string itemType)
    {
        this.itemType = itemType;
        Debug.Log(itemType);
    }

    public void EmptyItemSlot()
    {
        this.itemType = null;
        count = 0;
    }

    public string GetItemType()
    {
        return this.itemType;
    }

}
