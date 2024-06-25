using UnityEngine;

public class GridDisplay : MonoBehaviour
{
    public GameObject gridPrefab;   // グリッドセルのプレハブ
    public int gridSize = 3;        // グリッドのサイズ（3なら3x3）

    private GameObject[,] gridCells;

    void Start()
    {
        gridCells = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(x - gridSize / 2, y - gridSize / 2, 0) + transform.position;
                gridCells[x, y] = Instantiate(gridPrefab, position, Quaternion.identity);
                gridCells[x, y].transform.parent = transform;
            }
        }
    }

    void Update()
    {
        UpdateGridPositions();
    }

    void UpdateGridPositions()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(x - gridSize / 2, y - gridSize / 2, 0) + transform.position;
                gridCells[x, y].transform.position = position;
            }
        }
    }
}
