using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager8 : MonoBehaviour
{
    public static CameraManager8 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft8;
    public GameObject ButtonRight8;
    public GameObject ButtonBack8;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position8 { get; set; } //Camer Position
        public Vector3 Rotate8 { get; set; } // Camera Degree
        public MoveNames MoveNames8 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left8 { get; set; }
        public string Right8 { get; set; }
        public string Back8 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

         {
            "Front8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(5, 2, -4),
                Rotate8 = new Vector3(0, 90, 0),
                MoveNames8 = new MoveNames
                {
                    Left8 = "RoomLeft8",
                    Right8 = "RoomRight8",
                    Back8 = "RoomBack8",
                }
            }

        },
        {
            "Door8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(9, 2, 2),
                Rotate8 = new Vector3(0, 90, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Front8",
                }
            }

        },
        {
            "Desk8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(13, 2, -7),
                Rotate8 = new Vector3(10, -80, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Front8",
                }
            }

        },
        {
            "PCMoniter8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(12, 2, -7),
                Rotate8 = new Vector3(0, -80, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Desk8",
                }
            }

        },
        {
            "PCPS8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(12, 2, -6),
                Rotate8 = new Vector3(50, -75, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Desk8",
                }
            }

        },
        {
            "PCPSOpen8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(12, 2, -6),
                Rotate8 = new Vector3(50, -75, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Desk8",
                }
            }

        },
        {
            "RoomLeft8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(5, 2, -3),
                Rotate8 = new Vector3(0, 0, 0),
                MoveNames8 = new MoveNames
                {
                    Left8 = "RoomBack8",
                    Right8 = "Front8",
                    Back8 = "RoomRight8",
                }
            }

        },
        {
            "Plant8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(2, 2, 2),
                Rotate8 = new Vector3(35, -15, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "RoomLeft8",
                }
            }

        },
        {
            "Drawer8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(8, 2, 2),
                Rotate8 = new Vector3(45, 0, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "RoomLeft8",
                }
            }

        },
        {
            "DrawerOpen8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(8, 2, 2),
                Rotate8 = new Vector3(45, 0, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Drawer8",
                }
            }

        },
        {
            "PCLack8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(4, 2, 2),
                Rotate8 = new Vector3(25, 15, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "RoomLeft8",
                }
            }

        },
        {
            "RoomRight8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(5, 2, -5),
                Rotate8 = new Vector3(0, 180, 0),
                MoveNames8 = new MoveNames
                {
                    Left8 = "Front8",
                    Right8 = "RoomBack8",
                    Back8 = "RoomLeft8",
                }
            }

        },
        {
            "Arm8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(2, 2, -9),
                Rotate8 = new Vector3(20, 170, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "RoomRight8",
                }
            }

        },
        {
            "ArmOpen8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(2, 2, -9),
                Rotate8 = new Vector3(20, 170, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Arm8",
                }
            }

        },
        {
            "RoomBack8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(8, 2, -5),
                Rotate8 = new Vector3(0, -90, 0),
                MoveNames8 = new MoveNames
                {
                    Left8 = "RoomRight8",
                    Right8 = "RoomLeft8",
                    Back8 = "Front8",
                }
            }

        },
        {
            "Table8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(1, 2, -3),
                Rotate8 = new Vector3(25, -45, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "RoomBack8",
                }
            }

        },
        {
            "Boxes8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(3, 2, -8),
                Rotate8 = new Vector3(8, -110, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "RoomBack8",
                }
            }

        },
        {
            "BoxesOpen8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(3, 2, -8),
                Rotate8 = new Vector3(8, -110, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "Boxes8",
                }
            }

        },
        {
            "Wall8",
            new CameraPositionInfo
            {
                Position8 = new Vector3(2, 2, -10),
                Rotate8 = new Vector3(0, -90, 0),
                MoveNames8 = new MoveNames
                {
                    Back8 = "BoxesOpen8",
                }
            }

        },
    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Front8");

        ButtonBack8.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames8.Back8);
        });
        ButtonLeft8.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames8.Left8);
        });
        ButtonRight8.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames8.Right8);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position8;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate8);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames8.Back8 == null)
            ButtonBack8.SetActive(false);
        else ButtonBack8.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames8.Left8 == null)
            ButtonLeft8.SetActive(false);
        else ButtonLeft8.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames8.Right8 == null)
            ButtonRight8.SetActive(false);
        else ButtonRight8.SetActive(true);
    }
}
