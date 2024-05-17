using UnityEngine;

[RequireComponent(typeof(GridRenderer))]
public class GridVisibility : MonoBehaviour
{
    private GridRenderer gridRenderer;
    private Transform playerTransform;

    //private bool isGridVisible = false;

    private void Start()
    {
        gridRenderer = GetComponent<GridRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //bool isVisible = IsGridVisible();

        //if (isVisible && !isGridVisible)
        //{
        //    gridRenderer.ShowGrid();
        //    isGridVisible = true;
        //}
        //else if (!isVisible && isGridVisible)
        //{
        //    gridRenderer.HideGrid();
        //    isGridVisible = false;
        //}
    }

    //private bool IsGridVisible()
    //{
    //    if (gridRenderer == null || playerTransform == null)
    //    {
    //        return false;
    //    }

    //    // プレイヤーとグリッドの位置の差を計算
    //    Vector3 playerPos = playerTransform.position;
    //    Vector3 gridPos = transform.position;
    //    float distanceX = Mathf.Abs(playerPos.x - gridPos.x);
    //    float distanceY = Mathf.Abs(playerPos.y - gridPos.y);

    //    // プレイヤーの周りの3x3マスにあるかどうかを判定
    //    if (distanceX <= 1.5f && distanceY <= 1.5f)
    //    {
    //        return true;
    //    }

    //    return false;
    //}
}
