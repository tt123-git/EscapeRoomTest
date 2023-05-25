using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager2 : MonoBehaviour
{
    
    public static CameraManager2 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft2;
    public GameObject ButtonRight2;
    public GameObject ButtonBack2;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position2 { get; set; } //Camer Position
        public Vector3 Rotate2 { get; set; } // Camera Degree
        public MoveNames MoveNames2 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left2 { get; set; }
        public string Right2 { get; set; }
        public string Back2 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

        {
            "Door2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-2, 2, 2),
                Rotate2 = new Vector3(5, 0, 0),
                MoveNames2 = new MoveNames
                {
                    Left2 = "RoomLeft2",
                    Right2 = "RoomRight2",
                    Back2 = "RoomBack2",
                }
            }
        },
        {
            "RoomLeft2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-1, 2, 2),
                Rotate2 = new Vector3(0, -90, 0),
                MoveNames2 = new MoveNames
                {
                    Left2 = "RoomBack2",
                    Right2 = "Door2",
                    Back2 = "RoomRight2",
                }
            }
        },
        {
            "RoomRight2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-2, 2, 2),
                Rotate2 = new Vector3(0, 90, 0),
                MoveNames2 = new MoveNames
                {
                    Left2 = "Door2",
                    Right2 = "RoomBack2",
                    Back2 = "RoomLeft2",
                }
            }
        },
        {
            "RoomBack2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-1, 2, 2),
                Rotate2 = new Vector3(0, -180, 0),
                MoveNames2 = new MoveNames
                {
                    Left2 = "RoomRight2",
                    Right2 = "RoomLeft2",
                    Back2 = "Door2",
                }
            }
        },
        {
            "Food2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-3, 2, 1),
                Rotate2 = new Vector3(5, -90, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "RoomLeft2",
                }
            }
        },
        {
            "Fridge2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-2, 2, 4),
                Rotate2 = new Vector3(0, -90, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "RoomLeft2",
                }
            }
        },
        {
            "FridgeOpen2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-2, 2, 4),
                Rotate2 = new Vector3(0, -90, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "Fridge2",
                }
            }
        },
        {
            "Closet2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-3, 1, -1),
                Rotate2 = new Vector3(0, -180, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "RoomBack2",
                }
            }
        },
        {
            "ClosetOpen2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(-3, 1, -1),
                Rotate2 = new Vector3(0, -180, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "Closet2",
                }
            }
        },
        {
            "WoodBox2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(0, 2, -2),
                Rotate2 = new Vector3(75, -180, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "RoomBack2",
                }
            }
        },
        {
            "TV2",
            new CameraPositionInfo
            {
                Position2 = new Vector3(1, 2, 1),
                Rotate2 = new Vector3(15, 90, 0),
                MoveNames2 = new MoveNames
                {
                    Back2 = "RoomRight2",
                }
            }
        },


    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Door2");

        ButtonBack2.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames2.Back2);
        });
        ButtonLeft2.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames2.Left2);
        });
        ButtonRight2.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames2.Right2);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position2;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate2);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames2.Back2 == null)
            ButtonBack2.SetActive(false);
        else ButtonBack2.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames2.Left2 == null)
            ButtonLeft2.SetActive(false);
        else ButtonLeft2.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames2.Right2 == null)
            ButtonRight2.SetActive(false);
        else ButtonRight2.SetActive(true);
    }
    
}
