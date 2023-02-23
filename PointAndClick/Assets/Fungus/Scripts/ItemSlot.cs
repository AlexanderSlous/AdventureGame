using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryItem item;
    private Inventory inventory;

    public Image image;
    private TextMeshProUGUI textBox;

    private Verb verb;
    private PointAndClickController AdventureController;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        textBox = GetComponentInChildren<TextMeshProUGUI>();

        verb = FindObjectOfType<Verb>();
        AdventureController = FindObjectOfType<PointAndClickController>();
    }

    public void DisplayItem(InventoryItem thisItem)
    {
        item = thisItem;
        textBox.text = item.itemName;
        image.sprite = item.itemIcon;
        gameObject.SetActive(true);
    }

    public void ClearItem()
    {
        item = null;
        image.sprite = null;
        gameObject.SetActive(false);
    }
    
    public void OnItemClick()
    {
        if (AdventureController.cutSceneInProgress) { return; }
        if (verb.verb == Verb.Action.Use && verb.currentItem != null)
        {
            inventory.CombineItems(verb.currentItem, item);
        }
        verb.verb = Verb.Action.Use;
        verb.currentItem = item;
        verb.UpdateVerbTextBox(null);
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        verb.hoveredItemSlot = item.itemName;
        verb.UpdateVerbTextBox(null);
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        verb.hoveredItemSlot = item.itemName;
        verb.UpdateVerbTextBox(null);
    }
}
