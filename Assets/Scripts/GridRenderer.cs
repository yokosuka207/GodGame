using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class GridRenderer : MonoBehaviour
{
    public Vector2Int gridSize; // グリッド全体のサイズ
    public float cellSize = 1f; // グリッドセルのサイズ
    private GameObject[,] gridCells;

    public Material material; // 使用するマテリアル
    public GameObject gridCellPrefab; // グリッドセルのプレハブ

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        gridCells = new GameObject[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 position = new Vector3(x * cellSize + 0.5f, y * cellSize + 0.5f, 0);
                gridCells[x, y] = Instantiate(gridCellPrefab, position, Quaternion.identity, transform);
                gridCells[x, y].SetActive(false); // 初期状態では非表示
            }
        }
    }

    public void UpdateGridDisplay(Vector2Int centerPosition, Vector2Int displaySize)
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int cellPosition = new Vector2Int(x, y);
                if (Mathf.Abs(cellPosition.x - centerPosition.x) <= displaySize.x / 2 &&
                    Mathf.Abs(cellPosition.y - centerPosition.y) <= displaySize.y / 2)
                {
                    gridCells[x, y].SetActive(true);
                }
                else
                {
                    gridCells[x, y].SetActive(false);
                }
            }
        }
    }
}
