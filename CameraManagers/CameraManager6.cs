using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager6 : MonoBehaviour
{
    public static CameraManager6 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft6;
    public GameObject ButtonRight6;
    public GameObject ButtonBack6;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position6 { get; set; } //Camer Position
        public Vector3 Rotate6 { get; set; } // Camera Degree
        public MoveNames MoveNames6 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left6 { get; set; }
        public string Right6 { get; set; }
        public string Back6 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

         {
            "Front6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(0, 2, 2),
                Rotate6 = new Vector3(0, 180, 0),
                MoveNames6 = new MoveNames
                {
                    Left6 = "RoomLeft6",
                    Right6 = "RoomRight6",
                    Back6 = "RoomBack6",
                }
            }

        },
         {
            "RoomLeft6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(0, 2, 2),
                Rotate6 = new Vector3(0, 90, 0),
                MoveNames6 = new MoveNames
                {
                    Left6 = "RoomBack6",
                    Right6 = "Front6",
                    Back6 = "RoomRight6",
                }
            }

        },
          {
            "RoomRight6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(0, 2, 2),
                Rotate6 = new Vector3(0, 90, 0),
                MoveNames6 = new MoveNames
                {
                    Left6 = "Front6",
                    Right6 = "RoomBack6",
                    Back6 = "RoomLeft6",
                }
            }

        },
         {
            "RoomBack6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(0, 2, 2),
                Rotate6 = new Vector3(0, 0, 0),
                MoveNames6 = new MoveNames
                {
                    Left6 = "RoomRight6",
                    Right6 = "RoomLeft6",
                    Back6 = "Front6",
                }
            }

        },
         


    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Front6");

        ButtonBack6.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames6.Back6);
        });
        ButtonLeft6.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames6.Left6);
        });
        ButtonRight6.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames6.Right6);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position6;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate6);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames6.Back6 == null)
            ButtonBack6.SetActive(false);
        else ButtonBack6.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames6.Left6 == null)
            ButtonLeft6.SetActive(false);
        else ButtonLeft6.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames6.Right6 == null)
            ButtonRight6.SetActive(false);
        else ButtonRight6.SetActive(true);
    }
}
