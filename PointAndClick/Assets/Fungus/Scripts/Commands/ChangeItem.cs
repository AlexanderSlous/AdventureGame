using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Item", "ChangeItem", "Adds or removes items")]

    [AddComponentMenu("")]

    public class ChangeItem : Command
    {
        [Tooltip("Reference to an InventoryItem scriptable object that fills the ItemSlots in the Inventory")]
        [SerializeField] protected InventoryItem item;

        [Tooltip("If add is true, item will be added to Inventory. If add is false, item will be removed")]
        [SerializeField] protected bool add;

        public override void OnEnter()
        {
            if (item != null)
            {
                if (add)
                {
                    item.itemOwned = true;
                }
                else
                {
                    item.itemOwned = false;
                }
            }

            Continue();
        }

        public override string GetSummary()
        {
            if (item == null)
            {
                return "Error: No item selected";
            }

            return item.itemName;
        }
    }
}
