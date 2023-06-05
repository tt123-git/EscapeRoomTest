using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDoorOpen : MonoBehaviour
{
    public string OpenPositionName;
    public Vector3 OpenRotate;

    void Start()
    {
        
    }

    void Update()
    {
        if (CameraManager.Instance != null && OpenPositionName == CameraManager.Instance.CurrentPositionName)
        {
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        }
        else if (CameraManager1.Instance != null && OpenPositionName == CameraManager1.Instance.CurrentPositionName)
        {
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        }
        else if (CameraManager2.Instance != null && OpenPositionName == CameraManager2.Instance.CurrentPositionName)
        {
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        }
        else if (CameraManager3.Instance != null && OpenPositionName == CameraManager3.Instance.CurrentPositionName)
        {
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        }
        else if (CameraManager4.Instance != null && OpenPositionName == CameraManager4.Instance.CurrentPositionName)
        {
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        }
        else if (CameraManager5.Instance != null && OpenPositionName == CameraManager5.Instance.CurrentPositionName)
        {
            gameObject.transform.localRotation = Quaternion.Euler(OpenRotate);
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.identity;
        }
   
    }
}
