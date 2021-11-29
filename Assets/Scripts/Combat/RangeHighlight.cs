using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RangeHighlight : MonoBehaviour
{
    private GameObject grid;
    private Tilemap rangeTilemap;
    [SerializeField] private Tile MoveTile;
    [SerializeField] private Tile AttackTile;
    private bool isHighlighting = false;
    public bool IsHighlighting
    {
        get => isHighlighting;
        set => isHighlighting = value; 
    }


    public void Awake()
    {
        grid = GameObject.Find("Grid");
        rangeTilemap = grid.GetComponentInChildren<Tilemap>();
    }

    public void ShowHighlight(int range, bool tileType)
    {
        GameObject emptyGO = new GameObject();
        Transform newTransform = emptyGO.transform;

        for (int y = -range; y <= range; y++)
        {
            for (int x = -range; x <= range; x++)
            {
                Vector3Int vec3Int = new Vector3Int( (int)(x + gameObject.transform.position.x), (int)(y + gameObject.transform.position.y), -1 );
                Tile tile = (tileType) ? MoveTile : AttackTile;


                newTransform.SetPositionAndRotation(vec3Int, new Quaternion());

                float distance = gameObject.GetComponent<UtilFuncs>().CheckDistance(newTransform).magnitude;

                if (distance <= range)
                {
                    rangeTilemap.SetTile(vec3Int, tile);
                }
            }
        }

        Destroy(emptyGO);
        isHighlighting = true;
    }

    public void hideHighlight()
    {
        rangeTilemap.ClearAllTiles();
        isHighlighting = false;
    }
}
