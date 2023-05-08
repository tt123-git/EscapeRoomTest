using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager1 : MonoBehaviour
{
    public static CameraManager1 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft1;
    public GameObject ButtonRight1;
    public GameObject ButtonBack1;
    

    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position1 { get; set; } //Camer Position
        public Vector3 Rotate1 { get; set; } // Camera Degree
        public MoveNames MoveNames1 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left1 { get; set; }
        public string Right1 { get; set; }
        public string Back1 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {
        
        {//Stage1
            "Door1",
            new CameraPositionInfo
            {
                Position1 = new Vector3(0, 1, 1),
                Rotate1 = new Vector3(4, 0, 0),
                MoveNames1 = new MoveNames
                {
                    Left1 = "RoomLeft1",
                    Right1 = "RoomRight1",
                    Back1 = "RoomBack1",
                }
            }
        },
        {
            "RoomLeft1",
            new CameraPositionInfo
            {
                Position1 = new Vector3(0, 1, 1),
                Rotate1 = new Vector3(4, -90, 0),
                MoveNames1 = new MoveNames
                {
                    Left1 = "RoomBack1",
                    Right1 = "Door1",
                    Back1 = "RoomRight1",
                }
            }
        },
        {
            "RoomRight1",
            new CameraPositionInfo
            {
                Position1 = new Vector3(0, 1, 1),
                Rotate1 = new Vector3(4, 90, 0),
                MoveNames1 = new MoveNames
                {
                    Left1 = "Door1",
                    Right1 = "RoomBack1",
                    Back1 = "RoomLeft1",
                }
            }
        },
        {
            "RoomBack1",
            new CameraPositionInfo
            {
                Position1 = new Vector3(0, 1, 1),
                Rotate1 = new Vector3(4, 180, 0),
                MoveNames1 = new MoveNames
                {
                    Left1 = "RoomRight1",
                    Right1 = "RoomLeft1",
                    Back1 = "Door1",
                }
            }
        },
        {
            "SandBox",
            new CameraPositionInfo
            {
                Position1 = new Vector3(0, 1, 0),
                Rotate1 = new Vector3(20, -100, 0),
                MoveNames1 = new MoveNames
                {
         
                    Back1 = "RoomLeft1",
                }
            }
        },
        {
            "Locker",
            new CameraPositionInfo
            {
                Position1 = new Vector3(1, 1, 2),
                Rotate1 = new Vector3(0, 80, 0),
                MoveNames1 = new MoveNames
                {

                    Back1 = "RoomRight1",
                }
            }
        },
        {
            "LockerDoor",
            new CameraPositionInfo
            {
                Position1 = new Vector3(1, 1, 2),
                Rotate1 = new Vector3(0, 80, 0),
                MoveNames1 = new MoveNames
                {

                    Back1 = "Locker",
                }
            }
        },
        {
            "RedBox",
            new CameraPositionInfo
            {
                Position1 = new Vector3(1, 1, -1),
                Rotate1 = new Vector3(0, 180, 0),
                MoveNames1 = new MoveNames
                {

                    Back1 = "RoomBack1",
                }
            }
        },
        {
            "RedBoxMoved",
            new CameraPositionInfo
            {
                Position1 = new Vector3(1, 1, -1),
                Rotate1 = new Vector3(0, 180, 0),
                MoveNames1 = new MoveNames
                {

                    Back1 = "RedBox",
                }
            }
        },


    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Door1");

        ButtonBack1.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames1.Back1);
        });
        ButtonLeft1.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames1.Left1);
        });
        ButtonRight1.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames1.Right1);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position1;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate1);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames1.Back1 == null)
            ButtonBack1.SetActive(false);
        else ButtonBack1.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames1.Left1 == null)
            ButtonLeft1.SetActive(false);
        else ButtonLeft1.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames1.Right1 == null)
            ButtonRight1.SetActive(false);
        else ButtonRight1.SetActive(true);
    }
}
