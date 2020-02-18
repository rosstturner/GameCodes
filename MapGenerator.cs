using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform boarderPrefab;
    public Transform flag1;
    public Transform flag2;
    public Transform flag3;
    public Transform flag4;
    public Transform barrierPrefab;
    public Transform gemPrefab;

    public Vector2 mapSize;

    [Range(0,25)]
    public int barrierCount;

    [Range(0,1)]
    public float outlinePercent;

    void Start(){
        GenerateMap();
        CreateBoarder();
        AddFlags();
        AddBarriersAndGems();
    }

    public void GenerateMap(){
        for (int x = 0; x < mapSize.x; x++){
            for (int y = 0; y < mapSize.y; y++){
                Vector3 tilePosition = new Vector3(-mapSize.x/2 + 0.5f + x, -0.3f, -mapSize.y/2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.left*90)) as Transform;
                newTile.localScale = Vector3.one * (1-outlinePercent);
            }
        }
    }

    public void CreateBoarder(){
        for (int x = 0; x < mapSize.x + 1; x++){
            Vector3 boarderPosition = new Vector3(-mapSize.x/2 + 0.5f + x, 0, -mapSize.y/2 + 0.5f - 1);
            Transform newBoarder = Instantiate(boarderPrefab, boarderPosition, Quaternion.Euler(Vector3.left*0)) as Transform;
            newBoarder.localScale = Vector3.one * (1-outlinePercent);
        }
        for (int x = -1; x < mapSize.x; x++){
            Vector3 boarderPosition = new Vector3(mapSize.x/2 - 0.5f - x, 0, mapSize.y/2 - 0.5f + 1);
            Transform newBoarder = Instantiate(boarderPrefab, boarderPosition, Quaternion.Euler(Vector3.left*0)) as Transform;
            newBoarder.localScale = Vector3.one * (1-outlinePercent);
        }
        for (int y = 0; y < mapSize.y; y++){
            Vector3 boarderPosition = new Vector3(mapSize.x/2 - 0.5f + 1, 0, mapSize.y/2 - 0.5f - y);
            Transform newBoarder = Instantiate(boarderPrefab, boarderPosition, Quaternion.Euler(Vector3.left*0)) as Transform;
            newBoarder.localScale = Vector3.one * (1-outlinePercent);
        }
        for (int y = -1; y < mapSize.y + 1; y++){
            Vector3 boarderPosition = new Vector3(-mapSize.x/2 + 0.5f - 1, 0, -mapSize.y/2 + 0.5f + y);
            Transform newBoarder = Instantiate(boarderPrefab, boarderPosition, Quaternion.Euler(Vector3.left*0)) as Transform;
            newBoarder.localScale = Vector3.one * (1-outlinePercent);
        }
    }

    public void AddFlags(){
        Vector3 flagPosition = new Vector3(-mapSize.x/2 + 0.5f, 1, -mapSize.y/2 + 0.5f);
        Transform newFlag = Instantiate(flag1, flagPosition, Quaternion.Euler(0f, 90f, 0f)) as Transform;
        newFlag.localScale = Vector3.one * ((1-outlinePercent) * 0.5f);

        Vector3 flagPosition2 = new Vector3(-mapSize.x/2 + 0.5f, 1, mapSize.y/2 - 0.5f);
        Transform newFlag2 = Instantiate(flag2, flagPosition2, Quaternion.Euler(0f, 270f, 0f)) as Transform;
        newFlag2.localScale = Vector3.one * ((1-outlinePercent) * 0.5f);

        Vector3 flagPosition3 = new Vector3(mapSize.x/2 - 0.5f, 1, mapSize.y/2 - 0.5f);
        Transform newFlag3 = Instantiate(flag3, flagPosition3, Quaternion.Euler(0f, 0f, 0f)) as Transform;
        newFlag3.localScale = Vector3.one * ((1-outlinePercent) * 0.5f);

        Vector3 flagPosition4 = new Vector3(mapSize.x/2 - 0.5f, 1, -mapSize.y/2 + 0.5f);
        Transform newFlag4 = Instantiate(flag4, flagPosition4, Quaternion.Euler(0f, 0f, 0f)) as Transform;
        newFlag4.localScale = Vector3.one * ((1-outlinePercent) * 0.5f);
       
    }

    public void AddBarriersAndGems(){

        Vector3 flagPosition = new Vector3(-mapSize.x/2 + 0.5f, 0, -mapSize.y/2 + 0.5f);
        Vector3 flagPosition2 = new Vector3(-mapSize.x/2 + 0.5f, 0, mapSize.y/2 - 0.5f);
        Vector3 flagPosition3 = new Vector3(mapSize.x/2 - 0.5f, 0, mapSize.y/2 - 0.5f);
        Vector3 flagPosition4 = new Vector3(mapSize.x/2 - 0.5f, 0, -mapSize.y/2 + 0.5f);

        for (int x = 0; x < mapSize.x; x++){
            for (int y = 0; y < mapSize.y; y++){
                Vector3 barrierPosition = new Vector3(-mapSize.x/2 + 0.5f + x, 0, -mapSize.y/2 + 0.5f + y);

                if (barrierPosition == flagPosition || barrierPosition == flagPosition2 || barrierPosition == flagPosition3 || barrierPosition == flagPosition4){


                } else {

                    int isBarrier = Random.Range(0,10);

                    if (isBarrier >5){
                        Transform newBarrier = Instantiate(barrierPrefab, barrierPosition, Quaternion.Euler(Vector3.left*90)) as Transform;
                        newBarrier.localScale = Vector3.one * (1-outlinePercent);
                    }

                    if (isBarrier <2){
                        Transform newGem = Instantiate(gemPrefab, barrierPosition, Quaternion.Euler(Vector3.left*0)) as Transform;
                        newGem.localScale = Vector3.one * ((1-outlinePercent) * 0.75f);
                    }
                }
            }
        }
    }
}