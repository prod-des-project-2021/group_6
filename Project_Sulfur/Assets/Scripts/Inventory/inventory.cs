using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour, IItemContainer
{

    public List<item_script> itemScripts = new List<item_script>();
    public static inventory instance;
    public crafting_ui_script craftingUI;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       transform.parent.GetComponentsInChildren<item_script>(true, itemScripts);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ItemCount(_Item item){
        int amount = 0;
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].item == item){
                amount = itemScripts[i].currentAmount;
            }
        }
        return amount;
    }
    
    public bool ContainsItem(_Item item){
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].item == item){
                if(itemScripts[i].currentAmount > 0){
                    return true;
                }
            }
        }
        return false;
    }
    public bool RemoveItem(_Item item){
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].item == item){
                if(itemScripts[i].currentAmount > 0){
                    itemScripts[i].currentAmount--;
                    if(itemScripts[i].currentAmount < 1){
                        itemScripts[i].item = null;
                    }
                    craftingUI.UpdateCraftingList();
                    return true;
                }else{
                    itemScripts[i].item = null;
                }
            }
        }
        return false;

        
    }
    public bool AddItem(_Item item){
        //check if there is an item
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].item == item){
                if(itemScripts[i].currentAmount < item_script.MAX_AMOUNT){
                    itemScripts[i].currentAmount++;
                    craftingUI.UpdateCraftingList();
                    return true;
                }
            }

        }
        //try to add the item if there is no same item
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].item == null){
                itemScripts[i].item = item;
                itemScripts[i].currentAmount++;
                craftingUI.UpdateCraftingList();
                return true;
            }
        }
        

        return false;
    }
    public bool IsFull(){
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].currentAmount < item_script.MAX_AMOUNT){
                return false;
            }
        }
        return true;
    }

    public bool ItemFits(_Item item, int amount){
        for (int i = 0; i < itemScripts.Count; i++)
        {
            if(itemScripts[i].item == item){
                if(itemScripts[i].currentAmount + amount < item_script.MAX_AMOUNT){
                    return true;
                }
            }
            if(itemScripts[i].item == null){
                return true;
            }
        }
        return false;
    }
    
}
