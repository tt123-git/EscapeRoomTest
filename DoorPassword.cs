using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPassword : MonoBehaviour
{
    private bool _IsOpen1 = false;
    public TapObjectChange[] TapChanges;
    public int[] AnswerIndexes;
    public string OpenPositionName;
    public GameObject OpenCollider;
    public GameObject[] ObjectsToActivate; 
    public GameObject PasswordUI;

    void Start()
    {

    }

    void Update()
    {
        if (_IsOpen1) return;

        for (int i = 0; i < TapChanges.Length; i++)
        {
            if (TapChanges[i].Index != AnswerIndexes[i])
                return;
        }
        //here is collect answer
        _IsOpen1 = true;
        foreach (var TapChange in TapChanges)
        {
            TapChange.enabled = false;
            TapChange.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        // 追加
        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.SetActive(true);
        }
        gameObject.SetActive(false);
        PasswordUI.SetActive(false);
        Invoke(nameof(CameraMovement), 0.5f);
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
            OpenCollider.SetActive(true);
        }
    }

}
