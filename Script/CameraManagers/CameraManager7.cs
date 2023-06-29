using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager7 : MonoBehaviour
{
    public static CameraManager7 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft7;
    public GameObject ButtonRight7;
    public GameObject ButtonBack7;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position7 { get; set; } //Camer Position
        public Vector3 Rotate7 { get; set; } // Camera Degree
        public MoveNames MoveNames7 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left7 { get; set; }
        public string Right7 { get; set; }
        public string Back7 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

         {
            "Front7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(1, 1, -1),
                Rotate7 = new Vector3(0, -90, 0),
                MoveNames7 = new MoveNames
                {
                    Left7 = "RoomLeft7",
                    Right7 = "RoomRight7",
                    Back7 = "RoomBack7",
                }
            }

        },
        {
            "Door7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(-1, 2, -3),
                Rotate7 = new Vector3(20, -90, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "Front7",
                }
            }

        },
        {
            "FrontBox7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(-2, 1, 1),
                Rotate7 = new Vector3(60, -90, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "Front7",
                }
            }

        },
        {
            "FrontDrawer7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(-2, 1, 0),
                Rotate7 = new Vector3(50, -120, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "Front7",
                }
            }

        },
        {
            "FrontDrawerOpen7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(-2, 1, 0),
                Rotate7 = new Vector3(50, -120, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "FrontDrawer7",
                }
            }

        },
        {
            "TV7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(-2, 1, 0),
                Rotate7 = new Vector3(10, -120, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "Front7",
                }
            }

        },
        {
            "RoomLeft7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(1, 1, 0),
                Rotate7 = new Vector3(0, -180, 0),
                MoveNames7 = new MoveNames
                {
                    Left7 = "RoomBack7",
                    Right7 = "Front7",
                    Back7 = "RoomRight7",
                }
            }

        },
        {
            "LeftBox7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(-1, 1, -3),
                Rotate7 = new Vector3(45, -195, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "RoomLeft7",
                }
            }

        },
        {
            "SnackBox7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(2, 1, -2),
                Rotate7 = new Vector3(0, 165, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "RoomLeft7",
                }
            }

        },
        {
            "RoomRight7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(1, 1, -2),
                Rotate7 = new Vector3(0, 0, 0),
                MoveNames7 = new MoveNames
                {
                    Left7 = "Front7",
                    Right7 = "RoomBack7",
                    Back7 = "RoomLeft7",
                }
            }

        },
        {
            "RightBox7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(2, 1, 1),
                Rotate7 = new Vector3(30, 15, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "RoomRight7",
                }
            }

        },
        {
            "Table7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(0, 1, 1),
                Rotate7 = new Vector3(90, 0, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "RoomRight7",
                }
            }

        },
        {
            "RoomBack7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(0, 1, -1),
                Rotate7 = new Vector3(10, 90, 0),
                MoveNames7 = new MoveNames
                {
                    Left7 = "RoomRight7",
                    Right7 = "RoomLeft7",
                    Back7 = "Front7",
                }
            }

        },
        {
            "BackBox7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(2, 1, -1),
                Rotate7 = new Vector3(60, 90, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "RoomBack7",
                }
            }

        },
        {
            "BigBox7",
            new CameraPositionInfo
            {
                Position7 = new Vector3(4, 1, 0),
                Rotate7 = new Vector3(80, 90, 0),
                MoveNames7 = new MoveNames
                {
                    Back7 = "RoomBack7",
                }
            }

        },
    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Front7");

        ButtonBack7.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames7.Back7);
        });
        ButtonLeft7.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames7.Left7);
        });
        ButtonRight7.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames7.Right7);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position7;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate7);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames7.Back7 == null)
            ButtonBack7.SetActive(false);
        else ButtonBack7.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames7.Left7 == null)
            ButtonLeft7.SetActive(false);
        else ButtonLeft7.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames7.Right7 == null)
            ButtonRight7.SetActive(false);
        else ButtonRight7.SetActive(true);
    }
}
