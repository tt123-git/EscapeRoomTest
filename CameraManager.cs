using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;
    //public GameObject DoorRight;
    //public GameObject DoorLeft;

    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position { get; set; } //Camer Position
        public Vector3 Rotate { get; set;} // Camera Degree
        public MoveNames MoveNames { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public string Back { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {
        {//Stage2
            "Door",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 5, 3),
                Rotate = new Vector3(20, -180, 0),
                MoveNames = new MoveNames
                {
                    Left = "RoomLeft",
                    Right = "RoomRight",
                    Back = "RoomBack",
                }
            }
        },
        {
            "RoomLeft",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 5, 3),
                Rotate = new Vector3(30, 100, 0),
                MoveNames = new MoveNames
                {
                    Right = "Door",
                    Left = "RoomBack",
                    Back = "RoomRight",
                }
            }
        },
        {
            "RoomRight",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 5, 3),
                Rotate = new Vector3(20, -120, 0),
                MoveNames = new MoveNames
                {
                    Left = "Door",
                    Right = "RoomBack",
                    Back = "RoomLeft",
                }
            }
        },
        {
            "RoomBack",
            new CameraPositionInfo
            {
                Position= new Vector3(-2, 4, 0),
                Rotate = new Vector3(20, 0, 0),
                MoveNames = new MoveNames
                {
                    Left = "RoomRight",
                    Right = "RoomLeft",
                    Back = "Door",
                }
            }
        },
        {
            "PcScreen",
            new CameraPositionInfo
            {
                Position= new Vector3(4, 3, 2),
                Rotate = new Vector3(0, -80, 0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft",
                    Left = "OpenBox",
                }
            }
        },
        {
            "OpenBox",
            new CameraPositionInfo
            {
                Position= new Vector3(4, 3, 1),
                Rotate = new Vector3(0, -120, 0),
                MoveNames = new MoveNames
                {
                    Back = "RoomLeft",
                    Right = "PcScreen",
                    Left = "Door",
                }
            }
        },
        {
            "OpenBoxOpen",
            new CameraPositionInfo
            {
                Position= new Vector3(4, 3, 1),
                Rotate = new Vector3(0, -125, 0),
                MoveNames = new MoveNames
                {
                    Back = "OpenBox",
                }
            }
        },
        {
            "Chair",
            new CameraPositionInfo
            {
                Position= new Vector3(-5, 2, 1),
                Rotate = new Vector3(70, 180, 0),
                MoveNames = new MoveNames
                {
                    Back = "RoomRight",
                }
            }
        },/*
        {//Stage1
            "Door1",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 1, 1),
                Rotate = new Vector3(4, 0, 0),
                MoveNames = new MoveNames
                {
                    Left = "RoomLeft1",
                    Right = "RoomRight1",
                    Back = "RoomBack1",
                }
            }
        },
        {
            "RoomLeft1",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 1, 1),
                Rotate = new Vector3(4, -90, 0),
                MoveNames = new MoveNames
                {
                    Left = "RoomBack1",
                    Right = "Door1",
                    Back = "RoomRight1",
                }
            }
        },
        {
            "RoomRight1",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 1, 1),
                Rotate = new Vector3(4, 90, 0),
                MoveNames = new MoveNames
                {
                    Left = "Door1",
                    Right = "RoomBack1",
                    Back = "RoomLeft1",
                }
            }
        },
        {
            "RoomBack1",
            new CameraPositionInfo
            {
                Position= new Vector3(0, 1, 1),
                Rotate = new Vector3(4, 180, 0),
                MoveNames = new MoveNames
                {
                    Left = "RoomRight1",
                    Right = "RoomLeft1",
                    Back = "Door1",
                }
            }
        },*/
        

    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Door");

        ButtonBack.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames.Back);
        });
        ButtonLeft.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames.Left);
        });
        ButtonRight.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames.Right);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;
        
        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames.Back == null)
            ButtonBack.SetActive(false);
        else ButtonBack.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames.Left == null)
            ButtonLeft.SetActive(false);
        else ButtonLeft.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames.Right == null)
            ButtonRight.SetActive(false);
        else ButtonRight.SetActive(true);
    }  
}
