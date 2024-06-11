using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target; // カメラが追跡する対象
    public SpriteRenderer background; // 背景のスプライトレンダラー

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // カメラの垂直サイズを取得
        Camera cam = Camera.main;
        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // 背景のバウンディングボックスを取得
        Bounds bounds = background.bounds;

        // カメラの移動範囲を計算
        minX = bounds.min.x + horzExtent;
        maxX = bounds.max.x - horzExtent;
        minY = bounds.min.y + vertExtent;
        maxY = bounds.max.y - vertExtent;
    }

    void LateUpdate()
    {
        // 追跡対象の位置を取得
        Vector3 targetPosition = target.position;

        // カメラの位置を範囲内に制限
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // カメラの位置を更新
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
