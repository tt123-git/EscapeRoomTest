using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapShowup : MonoBehaviour
{
    public GameObject uiCanvas; // アクティブにするUI Canvas
    public Collider colliderToTap; // タップするコライダー
    public string OpenPositionName;

    private bool canvasActive = false; // Canvasがアクティブ状態かどうか

    /*
     * コライダーがアクティブ化出来てないからそれを直す
     */

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックされた場合
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // カメラからマウス座標へレイを飛ばす
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // レイが何かに当たった場合
            {
                if (hit.collider == colliderToTap) // 指定したコライダーまたは新しく設定したコライダーをタップした場合
                {
                    canvasActive = !canvasActive; // Canvasのアクティブ状態を反転させる
                    uiCanvas.SetActive(canvasActive); // Canvasのアクティブ状態に合わせてUIをアクティブ化または非アクティブ化する
                }
            }
        }
        
    }

    public void DeactivateCanvas()
    {
        uiCanvas.SetActive(false);
        canvasActive = false;
    }

    
    private void CameraMovement()
    {
        if (CameraManager.Instance != null || CameraManager1.Instance != null || CameraManager2.Instance != null || CameraManager3.Instance != null) // どちらかが null でないことを確認
        {
            if (CameraManager.Instance != null) // CameraManager インスタンスが null でない場合
            {
                CameraManager.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else if (CameraManager1.Instance != null)
            {
                CameraManager1.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else if (CameraManager2.Instance != null)
            {
                CameraManager2.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else
            {
                CameraManager3.Instance.ChangeCameraPosition(OpenPositionName);
            }
            colliderToTap.gameObject.SetActive(true);
        }
    }
}
