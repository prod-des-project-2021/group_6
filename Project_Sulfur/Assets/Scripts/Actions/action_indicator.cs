using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action_indicator : MonoBehaviour
{
    public get_my_tile_manager getMyTileManager;
    public tile_manager tileManager;
    public int damageAmount;
    
    public float activateSpeed;
    public float activeDuration;
    bool isSet;


    public int breakAmount;
    public int axeToughness;
    public int pickToughness;

    public GameObject breakingIndicatorPrefab;

    public LayerMask actionMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetupValues(int _damageAmount, float _activateSpeed, float _activeDuration){
        damageAmount = _damageAmount;
        activateSpeed = _activateSpeed;
        activeDuration = _activeDuration;
        
        isSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(tileManager == null){
            tileManager = getMyTileManager.tileManager;
        }
        
        if(isSet && tileManager != null){
            if(activateSpeed < 0){
                //activate: hit or break something

                Vector3Int cellPosition = tileManager.maps[1].WorldToCell(transform.position);
                _Tile currentTile = tile_dictionary.GetTileSO(cellPosition, tileManager.maps[1]);

                //check if there already is a breaking or action indicator
                Collider2D actionCollider = Physics2D.OverlapCircle(transform.position + new Vector3(.5f,.5f,0), .1f, actionMask);
                if(actionCollider != null){
                    Debug.Log("found action");
                    //there already is a action or breaking
                    //find out what type
                    if(actionCollider.transform.GetComponent<action_indicator>() != null){
                        //this is an action indicator

                    }else{
                        // this is a breaking indicator
                        // try to break the tile
                        actionCollider.GetComponent<breaking_indicator>().Damage(51);

                    }
                }else{
                    Debug.Log("did not find action");
                    // no collider found
                    //translate worldpos to gridpos
                    if(currentTile != null && currentTile.isDemolishable){
                        
                        //start breaking the tile there is no breaking indicator
                        GameObject newBreakingIndicator = Instantiate(breakingIndicatorPrefab, transform.position, Quaternion.identity);
                        if(newBreakingIndicator.GetComponent<breaking_indicator>() != null){
                            newBreakingIndicator.GetComponent<breaking_indicator>().SetupValues(currentTile.structureHealth, currentTile, tileManager, cellPosition);
                        }
                        

                    }
                }

                
                activeDuration -= Time.deltaTime;
                if(activeDuration < 0){
                    Destroy(this.gameObject);
                }
            }else{
                activateSpeed -= Time.deltaTime;
            }
        }
    }

    void Breaking(){

    }
}