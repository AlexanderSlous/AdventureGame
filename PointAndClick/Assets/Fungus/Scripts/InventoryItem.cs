using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New InventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public bool itemOwned;

    public string itemName;
    public Sprite itemIcon;

    public bool combinable;
    public InventoryItem[] combinableItems;
    public string[] successBlockNames;
    public string failBlockName;
}
