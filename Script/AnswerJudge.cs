using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerJudge : MonoBehaviour
{
    private bool _IsOpen = false;

    public TapObjectChange[] TapChanges;
    public int[] AnswerIndexes;
    public string OpenPositionName;
    public GameObject Answer;

    void Start()
    {

    }

    void Update()
    {
        if (_IsOpen) return;

        for (int i = 0; i < TapChanges.Length; i++)
        {
            if (TapChanges[i].Index != AnswerIndexes[i])
                return;
        }
        //here is collect answer
        _IsOpen = true;
        foreach (var TapChange in TapChanges)
        {
            TapChange.enabled = false;
            TapChange.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        Answer.SetActive(true); // ドアが開く代わりに指定されたオブジェクトをアクティブ化する

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
        }
    }
}
