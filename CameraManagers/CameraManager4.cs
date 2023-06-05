using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager4 : MonoBehaviour
{
    public static CameraManager4 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft4;
    public GameObject ButtonRight4;
    public GameObject ButtonBack4;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position4 { get; set; } //Camer Position
        public Vector3 Rotate4 { get; set; } // Camera Degree
        public MoveNames MoveNames4{ get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left4{ get; set; }
        public string Right4 { get; set; }
        public string Back4 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

         {
            "Front4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 2, 0),
                Rotate4 = new Vector3(25, -90, 0),
                MoveNames4 = new MoveNames
                {
                    Left4 = "RoomLeft4",
                    Right4 = "RoomRight4",
                    Back4 = "RoomBack4",
                }
            }
        },
        {
            "Door4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 2, 1),
                Rotate4 = new Vector3(20, -90, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "Front4",
                }
            }
        },
        {
            "Drawer4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(-1, 2, -1),
                Rotate4 = new Vector3(70, -90, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "Front4",
                }
            }
        },
        {
            "Drawer4Open",
            new CameraPositionInfo
            {
                Position4 = new Vector3(-1, 2, -1),
                Rotate4 = new Vector3(70, -90, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "Drawer4",
                }
            }
        },
        {
            "Mirror4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(-1, 2, -1),
                Rotate4 = new Vector3(15, -90, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "Front4",
                }
            }
        },
        {
            "RoomLeft4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 2, 0),
                Rotate4 = new Vector3(25, 180, 0),
                MoveNames4 = new MoveNames
                {
                    Left4 = "RoomBack4",
                    Right4 = "Front4",
                    Back4 = "RoomRight4",
                }
            }
        },
        {
            "Drawer42",
            new CameraPositionInfo
            {
                Position4 = new Vector3(1, 1, -1),
                Rotate4 = new Vector3(35, 180, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "RoomLeft4",
                }
            }
        },
        {
            "Drawer42Open",
            new CameraPositionInfo
            {
                Position4 = new Vector3(1, 1, -1),
                Rotate4 = new Vector3(35, 180, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "Drawer42",
                }
            }
        },
        {
            "Pillow4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 2, -1),
                Rotate4 = new Vector3(50, 180, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "RoomLeft4",
                }
            }
        },
        {
            "RoomRight4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 1, -1),
                Rotate4 = new Vector3(0, 0, 0),
                MoveNames4 = new MoveNames
                {
                    Left4 = "Front4",
                    Right4 = "RoomBack4",
                    Back4 = "RoomLeft4",
                }
            }
        },
        {
            "Plate4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(1, 2, 1),
                Rotate4 = new Vector3(20, -6, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "RoomRight4",
                }
            }
        },
        {
            "TV4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 2, 1),
                Rotate4 = new Vector3(30, 0, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "RoomRight4",
                }
            }
        },
        {
            "RoomBack4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(0, 2, 0),
                Rotate4 = new Vector3(25, 90, 0),
                MoveNames4 = new MoveNames
                {
                    Left4 = "RoomRight4",
                    Right4 = "RoomLeft4",
                    Back4 = "Front4",
                }
            }
        },
        {
            "Box4",
            new CameraPositionInfo
            {
                Position4 = new Vector3(1, 1, 1),
                Rotate4 = new Vector3(25, 90, 0),
                MoveNames4 = new MoveNames
                {
                    Back4 = "RoomBack4",
                }
            }
        },

    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Front4");

        ButtonBack4.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames4.Back4);
        });
        ButtonLeft4.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames4.Left4);
        });
        ButtonRight4.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames4.Right4);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position4;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate4);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames4.Back4 == null)
            ButtonBack4.SetActive(false);
        else ButtonBack4.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames4.Left4 == null)
            ButtonLeft4.SetActive(false);
        else ButtonLeft4.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames4.Right4 == null)
            ButtonRight4.SetActive(false);
        else ButtonRight4.SetActive(true);
    }
}
