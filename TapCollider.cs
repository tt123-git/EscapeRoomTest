using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapCollider : MonoBehaviour
{
    public string EnableCameraPositionName;
    void Start()
    {
        var CurrentTrigger = gameObject.AddComponent<EventTrigger>();

        var EntryClick = new EventTrigger.Entry();
        EntryClick.eventID = EventTriggerType.PointerClick;
        EntryClick.callback.AddListener((x) => OnTap());

        CurrentTrigger.triggers.Add(EntryClick);
    }

    void Update()
    {
        if (CameraManager.Instance != null && EnableCameraPositionName == CameraManager.Instance.CurrentPositionName)
            GetComponent<BoxCollider>().enabled = true;
        else if (CameraManager1.Instance != null && EnableCameraPositionName == CameraManager1.Instance.CurrentPositionName)
            GetComponent<BoxCollider>().enabled = true;
        else if (CameraManager2.Instance != null && EnableCameraPositionName == CameraManager2.Instance.CurrentPositionName)
            GetComponent<BoxCollider>().enabled = true;
        else if (CameraManager3.Instance != null && EnableCameraPositionName == CameraManager3.Instance.CurrentPositionName)
            GetComponent<BoxCollider>().enabled = true;
        else if (CameraManager4.Instance != null && EnableCameraPositionName == CameraManager4.Instance.CurrentPositionName)
            GetComponent<BoxCollider>().enabled = true;
        else
            GetComponent<BoxCollider>().enabled = false;
    }

    protected virtual void OnTap()
    {
        
    }
}
