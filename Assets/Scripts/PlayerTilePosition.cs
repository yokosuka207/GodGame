using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTilePosition : MonoBehaviour
{
    public Tilemap tilemap;
    Vector3Int cellPosition;

    private void Update()
    {
        // プレイヤーの位置を取得
        Vector3 playerPosition = transform.position;

        // プレイヤーの位置をタイルマップの座標に変換
        cellPosition = tilemap.WorldToCell(playerPosition);

        // タイルマップの座標にあるタイルを取得
        TileBase tile = tilemap.GetTile(cellPosition);

        if (tile != null)
        {
            //Debug.Log("Player is on tile: " + tile.name + " at position " + cellPosition);
        }
        else
        {
           //Debug.Log(cellPosition);
        }
    }

    public Vector3Int GetTilePos()
    {
        return cellPosition;
    }
}
