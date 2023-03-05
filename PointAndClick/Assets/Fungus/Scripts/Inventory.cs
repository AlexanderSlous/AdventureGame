using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;

public class Inventory : MonoBehaviour
{
    private MenuDialog[] menuDialogs;
    private SayDialog[] sayDialogs;
    public CanvasGroup canvasGroup;
    private PointAndClickController AdventureController;

    public InventoryItem[] inventoryItems;
    public ItemSlot[] itemSlots;

    private Flowchart[] flowcharts;

    // Start is called before the first frame update
    void Start()
    {
        menuDialogs = FindObjectsOfType<MenuDialog>();
        sayDialogs = FindObjectsOfType<SayDialog>();
        canvasGroup = GetComponent<CanvasGroup>();
        AdventureController = FindObjectOfType<PointAndClickController>();
        flowcharts = FindObjectsOfType<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ActivateInventory();
        }
    }

    public void ActivateInventory()
    {
        ToggleInventory(!canvasGroup.interactable);
    }

    private void ToggleInventory(bool setting)
    {
        ToggleCanvasGroup(canvasGroup, setting);
        InitializeItemSlots();

        if (AdventureController.cutSceneInProgress)
        {
            AdventureController.inDialogue = setting;
        }

        foreach (MenuDialog menuDialog in menuDialogs)
        {
            ToggleCanvasGroup(menuDialog.GetComponent<CanvasGroup>(), !setting);
        }
        foreach (SayDialog sayDialog in sayDialogs)
        {
            sayDialog.dialogEnabled = !setting;
            if (setting) { Time.timeScale = 0f; } else { Time.timeScale = 1f; }
            ToggleCanvasGroup(sayDialog.GetComponent<CanvasGroup>(), !setting);
        }
    }

    public void InitializeItemSlots()
    {
        Debug.Log("Item slots initialized");
        List<InventoryItem> ownedItems = GetOwnedItems(inventoryItems.ToList());
        
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < ownedItems.Count)
            {
                itemSlots[i].DisplayItem(ownedItems[i]);
            }
            else
            {
                itemSlots[i].ClearItem();
            }
        }    
    }

    public List<InventoryItem> GetOwnedItems(List<InventoryItem> inventoryItems)
    {
        Debug.Log("Owned items fetched");
        List<InventoryItem> ownedItems = new List<InventoryItem>();
        foreach (InventoryItem item in inventoryItems)
        {
            if (item.itemOwned)
            {
                ownedItems.Add(item);
            }
        }
        return ownedItems;
    }

    public void CombineItems(InventoryItem item1, InventoryItem item2)
    {
        if (item1.combinable == true && item2.combinable == true)
        {
            for (int i = 0; i < item1.combinableItems.Length; i++)
            {
                if (item1.combinableItems[i] == item2)
                {
                    foreach (Flowchart flowchart in flowcharts)
                    {
                        if (flowchart.HasBlock(item1.successBlockNames[i]))
                        {
                            ToggleInventory(false);
                            AdventureController.EnterDialogue();
                            flowchart.ExecuteBlock(item1.successBlockNames[i]);
                        }
                    }
                }
                        
            }
        }
    }

    private void ToggleCanvasGroup(CanvasGroup canvasGroup, bool setting)
    {
        canvasGroup.alpha = setting ? 1f : 0f;
        canvasGroup.interactable = setting;
        canvasGroup.blocksRaycasts = setting;
    }
}
