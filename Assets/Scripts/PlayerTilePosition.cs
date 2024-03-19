using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTilePosition : MonoBehaviour
{
    public Tilemap tilemap;

    private void Update()
    {
        // �v���C���[�̈ʒu���擾
        Vector3 playerPosition = transform.position;

        // �v���C���[�̈ʒu���^�C���}�b�v�̍��W�ɕϊ�
        Vector3Int cellPosition = tilemap.WorldToCell(playerPosition);

        // �^�C���}�b�v�̍��W�ɂ���^�C�����擾
        TileBase tile = tilemap.GetTile(cellPosition);

        if (tile != null)
        {
            Debug.Log("Player is on tile: " + tile.name + " at position " + cellPosition);
        }
        else
        {
            Debug.Log("Player is not on any tile");
        }
    }
}
