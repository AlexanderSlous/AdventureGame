using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class Verb : MonoBehaviour
{
    public string walkString = "Walk to ";
    public string useString = "Use ";

    public string currentClickable;
    public InventoryItem currentItem;
    public string hoveredItemSlot;
    public bool combinability;

    public Inventory inventory;

    public enum Action { Walk, Use};

    public Action verb = Action.Walk;

    private TextMeshProUGUI verbTextBox;

    private Flowchart[] flowcharts;

    private void Start()
    {
        verbTextBox = GetComponentInChildren<TextMeshProUGUI>();
        verbTextBox.text = "";
        flowcharts = FindObjectsOfType<Flowchart>();
        inventory = FindObjectOfType<Inventory>();
    }

    public void UpdateVerbTextBox(string currentClickable)
    {
        SetVerbInFlowchart();
        if (verb == Action.Walk)
        {
            combinability = false;
            verbTextBox.text = walkString + currentClickable;
        }
        else if (verb == Action.Use)
        {
            if (inventory.canvasGroup.interactable == true)
            {
                combinability = true;
                verbTextBox.text = useString + " " + currentItem.itemName + " with " + hoveredItemSlot;
            }
            else if (currentClickable == null) { verbTextBox.text = useString + " " + currentItem.itemName + " with "; }
            else
            {
                combinability = false;
                verbTextBox.text = useString + " " + currentItem.itemName + " with " + currentClickable;
            }
        }
    }

    private void SetVerbInFlowchart()
    {
        foreach (Flowchart flowchart in flowcharts)
        {
            if (flowchart.HasVariable("verb"))
            {
                flowchart.SetStringVariable("verb", verb.ToString());
            }
            if (currentItem == null) { return; }
            if (flowchart.HasVariable("currentItem"))
            {
                flowchart.SetStringVariable("currentItem", currentItem.itemName);
            }
        }
    }
}
