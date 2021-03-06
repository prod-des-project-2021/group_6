using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class _Item : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public Sprite placeSprite;

    public _Tile tile;

    public _CraftingRecipe craftingRecipe;

    public float pickUpDistance = 2f;

    public bool hasAction;

    public int baseDamage;

    //action indicator
    public float activateSpeed;
    public float activeDuration;

    //what can be broken
    public int axeToughness;
    public int pickToughness;


}
