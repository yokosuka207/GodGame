using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTilePosition : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject markerPrefab; // マーカーのプレハブ
    private GameObject markerInstance; // マーカーのインスタンス
    private Vector3Int cellPosition;

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
            Debug.Log("Player is on tile: " + tile.name + " at position " + cellPosition);

            // タイルの中心座標を取得
            Vector3 tileCenter = tilemap.GetCellCenterWorld(cellPosition);

            // マーカーが存在しない場合はインスタンスを生成する
            if (markerInstance == null)
            {
                markerInstance = Instantiate(markerPrefab, tileCenter, Quaternion.identity);
            }
            // マーカーが存在する場合は位置を更新する
            else
            {
                markerInstance.transform.position = tileCenter;
            }
        }
        else
        {
            Debug.Log("Player is not on any tile");

            // マーカーが存在する場合は削除する
            if (markerInstance != null)
            {
                Destroy(markerInstance);
                markerInstance = null;
            }
        }
    }

    public Vector3Int GetTilePos()
    {
        return cellPosition;
    }
}
