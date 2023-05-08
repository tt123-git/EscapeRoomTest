using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObjectMove : MonoBehaviour
{
    public Vector3 MovedPosition;

    // オブジェクトが移動中かどうかを表すフラグ
    private bool isMoving = false;

    private void Update()
    {
        // オブジェクトが移動中でなければ、タップされたら移動する
        if (!isMoving && Input.GetMouseButtonUp(0))
        {
            // タップされた位置からRayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Rayがタップされたオブジェクトに当たった場合、オブジェクトを移動する
                if (hit.collider.gameObject == gameObject)
                {
                    // オブジェクトを移動開始
                    isMoving = true;
                    gameObject.transform.position = MovedPosition;
                }
            }
        }
    }
}