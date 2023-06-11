using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCameraMovement : TapCollider
{
    public string MovePositionName;
    protected override void OnTap()
    { 
        base.OnTap();
        if (CameraManager.Instance != null)
        {
            CameraManager.Instance.ChangeCameraPosition(MovePositionName);
        }
        else if (CameraManager1.Instance != null)
        {
            CameraManager1.Instance.ChangeCameraPosition(MovePositionName);
        }
        else if (CameraManager2.Instance != null)
        {
            CameraManager2.Instance.ChangeCameraPosition(MovePositionName);
        }
        else if (CameraManager3.Instance != null)
        {
            CameraManager3.Instance.ChangeCameraPosition(MovePositionName);
        }
        else if (CameraManager4.Instance != null)
        {
            CameraManager4.Instance.ChangeCameraPosition(MovePositionName);
        }
        else if (CameraManager5.Instance != null)
        {
            CameraManager5.Instance.ChangeCameraPosition(MovePositionName);
        }
        else if (CameraManager6.Instance != null)
        {
            CameraManager6.Instance.ChangeCameraPosition(MovePositionName);
        }
    }
}
