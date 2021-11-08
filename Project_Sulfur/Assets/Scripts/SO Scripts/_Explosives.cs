using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Explosive", menuName = "ScriptableObjects/Tiles/Explosive")]
public class _Explosives : _Tile
{
    public int ticksToExplode;

    public GameObject explosion;
    public GameObject nugget;

    public _Tile destroys;
    public _Tile replacedWith;

    private Quaternion myRotation = Quaternion.identity;
    
    
    public override void Do(Vector3Int tilePosition,tile_manager tileManager, int entityIndex, object sender)
    {
        
        //myRotation.eulerAngles = new Vector3(-90,0,0);
            
        
        tileManager.entityUpdater.saveValues[entityIndex]++; 

        //Debug.Log(tileManager.entityUpdater.saveValues[entityIndex]);
        if(tileManager.entityUpdater.saveValues[entityIndex] >= ticksToExplode){
            //Debug.Log("Explosion");
            //activate correct tilemanager
            Vector3 worldPosition = tileManager.maps[1].CellToWorld(tilePosition);
            tile_manager currentTileManager = tileManager.CheckTileManager(worldPosition + new Vector3Int(1,0,0));
            Vector3Int cellPosition = currentTileManager.maps[1].WorldToCell(worldPosition + new Vector3Int(1,0,0));
            
            //check right of tnt position if wall and replace it
            if(currentTileManager != null){
                _Tile rightTile = tile_dictionary.GetTileSO(cellPosition, currentTileManager.maps[1]);
                    //maybe destructible bool in SO??
                    //Debug.Log(rightTile + " " + (tilePosition + new Vector3Int(1,0,0)));
                    if(rightTile == destroys){
                        //we found wall -> destroy it
                        
                        currentTileManager.ReplaceTile(cellPosition, null, currentTileManager.maps[1]);
                        if(nugget != null){
                            Instantiate(nugget, worldPosition + new Vector3Int(1,0,0), Quaternion.identity);
                        }
                        
                    }
                
            }
            currentTileManager = tileManager.CheckTileManager(worldPosition + new Vector3Int(-1,0,0));
            cellPosition = currentTileManager.maps[1].WorldToCell(worldPosition + new Vector3Int(-1,0,0));
            //check left of tnt position if wall and replace it
            if(currentTileManager != null){
                _Tile rightTile = tile_dictionary.GetTileSO(cellPosition, currentTileManager.maps[1]);
                    //maybe destructible bool in SO??
                    //Debug.Log(rightTile + " " + (tilePosition + new Vector3Int(1,0,0)));
                    if(rightTile == destroys){
                        //we found wall -> destroy it
                        
                        currentTileManager.ReplaceTile(cellPosition, null, currentTileManager.maps[1]);
                        if(nugget != null){
                            Instantiate(nugget, worldPosition + new Vector3Int(-1,0,0), Quaternion.identity);
                        }
                        
                    }
                
            }
            currentTileManager = tileManager.CheckTileManager(worldPosition + new Vector3Int(0,1,0));
            cellPosition = currentTileManager.maps[1].WorldToCell(worldPosition + new Vector3Int(0,1,0));

            //check up of tnt position if wall and replace it
            if(currentTileManager != null){
                _Tile rightTile = tile_dictionary.GetTileSO(cellPosition, currentTileManager.maps[1]);
                    //maybe destructible bool in SO??
                    //Debug.Log(rightTile + " " + (tilePosition + new Vector3Int(1,0,0)));
                    if(rightTile == destroys){
                        //we found wall -> destroy it
                        
                        currentTileManager.ReplaceTile(cellPosition, null, currentTileManager.maps[1]);
                        if(nugget != null){
                            Instantiate(nugget, worldPosition + new Vector3Int(0,1,0), Quaternion.identity);
                        }
                        
                    }
                
            }
            currentTileManager = tileManager.CheckTileManager(worldPosition + new Vector3Int(0,-1,0));
            cellPosition = currentTileManager.maps[1].WorldToCell(worldPosition + new Vector3Int(0,-1,0));

            //check down of tnt position if wall and replace it
            if(currentTileManager != null){
                _Tile rightTile = tile_dictionary.GetTileSO(cellPosition, currentTileManager.maps[1]);
                    //maybe destructible bool in SO??
                    //Debug.Log(rightTile + " " + (tilePosition + new Vector3Int(1,0,0)));
                    if(rightTile == destroys){
                        //we found wall -> destroy it
                        
                        currentTileManager.ReplaceTile(cellPosition, null, currentTileManager.maps[1]);
                        if(nugget != null){
                            Instantiate(nugget, worldPosition + new Vector3Int(0,-1,0), Quaternion.identity);
                        }
                        
                    }
                
            }
            
            //remove thing
            tileManager.entityUpdater.removeList.Add(tilePosition);
            
            //tick_system.OnTick -= tileManager.entityUpdater.UpdateEntitys;
            tileManager.ReplaceTile(tilePosition, null, tileManager.maps[1]);
            //tick_system.OnTick -= this;
            tileManager.entityUpdater.valueRemoveList.Add(tileManager.entityUpdater.saveValues[entityIndex]);
            
            
            Instantiate(explosion, worldPosition, Quaternion.identity);
        }
        /*
        if(!setTick){
            currentTick = 0;
            setTick = true;
        }
        */
        //transform.position = transform.forward * 1f;
        //kaboom
        //Debug.Log(tileManager.vertices[tileIndex * 4 + 0]);
        //Debug.Log(tileManager.vertices[tileIndex * 4 + 0]);
        //tileManager.vertices[tileIndex * 4 + 0] = new Vector3(6,6);
        //tileManager.vertices[tileIndex * 4 + 1] = new Vector3(6,7); 
        //tileManager.vertices[tileIndex * 4 + 2] = new Vector3(7,7); 
        //tileManager.vertices[tileIndex * 4 + 3] = new Vector3(7,6); 
        //Debug.Log(tileManager.vertices[tileIndex * 4 + 0]); 
        
        //tileManager.GetComponent<MeshFilter>().mesh.vertices = tileManager.vertices.ToArray();
    }
}
