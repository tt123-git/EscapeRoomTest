using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJudge : MonoBehaviour
{
    private bool _IsOpen = false;

    public TapObjectChange[] TapChanges;
    public int[] AnswerIndexes;
    public string OpenPositionName;
    public GameObject OpenCollider;
   
    void Start()
    {
        
    }

    void Update()
    {
        if (_IsOpen) return;

        for(int i = 0; i < TapChanges.Length; i++) 
        {
            if (TapChanges[i].Index != AnswerIndexes[i])
                return;
        }
        //here is collect answer
        _IsOpen= true;
        foreach(var TapChange in TapChanges) 
        {
            TapChange.enabled = false;
            TapChange.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        Invoke(nameof(CameraMovement), 0.5f);
    }

    private void CameraMovement()
    {
        if (CameraManager.Instance != null || CameraManager1.Instance != null || CameraManager2.Instance != null || CameraManager3.Instance != null || CameraManager4.Instance != null
            || CameraManager5.Instance != null) // どちらかが null でないことを確認
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
            else if (CameraManager3.Instance != null)
            {
                CameraManager3.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else if (CameraManager4.Instance != null)
            {
                CameraManager4.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else
            {
                CameraManager5.Instance.ChangeCameraPosition(OpenPositionName);
            }
            OpenCollider.SetActive(true);
        }
    }
}
