using UnityEngine;

public class PlayerGridController : MonoBehaviour
{
    public GridRenderer gridRenderer;
    public Vector2Int displaySize = new Vector2Int(3, 3);

    void Update()
    {
        UpdateGridDisplay();
    }

    void UpdateGridDisplay()
    {
        Vector2Int playerGridPosition = new Vector2Int(
            Mathf.RoundToInt(transform.position.x - 0.5f),
            Mathf.RoundToInt(transform.position.y - 0.5f)
        );

        gridRenderer.UpdateGridDisplay(playerGridPosition, displaySize);
    }
}
