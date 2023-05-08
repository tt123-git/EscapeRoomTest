using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapShowup : MonoBehaviour
{
    public GameObject uiCanvas; // アクティブにするUI Canvas
    public Collider colliderToTap; // タップするコライダー

    private float lastTapTime; // 前回タップした時間
    private float tapDelay = 0.2f; // タップとして認識する時間間隔

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックされた場合
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // カメラからマウス座標へレイを飛ばす
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // レイが何かに当たった場合
            {
                if (hit.collider == colliderToTap) // 指定したコライダーをタップした場合
                {
                    if (Time.time - lastTapTime < tapDelay) // 前回タップしてからの時間が一定以下であれば
                    {
                        if (uiCanvas.activeSelf == true) // UIがアクティブ状態の場合
                        {
                            uiCanvas.SetActive(false); // UIを非アクティブにする
                        }
                    }
                    else
                    {
                        if (uiCanvas.activeSelf == false) // UIが非アクティブ状態の場合
                        {
                            uiCanvas.SetActive(true); // UIをアクティブにする
                        }
                    }
                    lastTapTime = Time.time; // 前回タップした時間を更新する
                }
            }
        }
    }
}
