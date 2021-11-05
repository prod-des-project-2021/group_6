using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObjects/Tiles/Tile")]
public class _Tile : Tilebase
{
    public new string name;
    public int buildLayer;

    public Sprite icon;
    
    public bool isWalkable;
    public bool needsUpdate;
    public bool isDemolishable;
    public _Item demolishItem;
    public bool isInteractable;
    public bool hasContainer;
    public int containerSize;
    //public bool needsItems;

    public bool hasMultipleSprites;
    public int xPos;
    public int yPos;

    //tiles in a tilemap that represent this scriptable object
    public TileBase[] tiles;

    public bool hasMultipleTiles;
    public TileBase[] tileParts;
    public Vector3Int[] tilePartPositions;


    //public Vector2[] uvs = new Vector2[4];

    public override void Do(Vector3Int tilePosition,tile_manager tileManager, int entityIndex, object sender){
        
        //Debug.Log(name);
    }

    

}