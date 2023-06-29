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
            "Door6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(2, 2, 0),
                Rotate6 = new Vector3(12, 180, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "Front6",
                }
            }

        },
         {
            "Desk6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(-2, 2, -2),
                Rotate6 = new Vector3(30, 200, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "Front6",
                }
            }

        },
          {
            "Element6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(-2, 2, -3),
                Rotate6 = new Vector3(0, 180, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "Front6",
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
            "Pizza6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(2, 2, 2),
                Rotate6 = new Vector3(15, 80, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "RoomLeft6",
                }
            }

        },
          {
            "PsBox6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(3, 3, 2),
                Rotate6 = new Vector3(50, 90, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "RoomLeft6",
                }
            }

        },
           {
            "PsBoxOpen6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(3, 3, 2),
                Rotate6 = new Vector3(50, 90, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "PsBox6",
                }
            }

        },
          {
            "RoomRight6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(0, 2, 2),
                Rotate6 = new Vector3(0, -90, 0),
                MoveNames6 = new MoveNames
                {
                    Left6 = "Front6",
                    Right6 = "RoomBack6",
                    Back6 = "RoomLeft6",
                }
            }

        },
           {
            "BallBox6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(-3, 3, 1),
                Rotate6 = new Vector3(45, -90, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "RoomRight6",
                }
            }

        },
         {
            "BallBoxOpen6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(-3, 3, 1),
                Rotate6 = new Vector3(45, -90, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "BallBox6",
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
         {
            "Drawers6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(0, 2, 5),
                Rotate6 = new Vector3(5, 0, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "RoomBack6",
                }
            }

        },
         {
            "DrawersPs6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(1, 1, 7),
                Rotate6 = new Vector3(15, 30, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "Drawers6",
                }
            }

        },
         {
            "DrawersPsOpen6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(1, 1, 7),
                Rotate6 = new Vector3(15, 30, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "DrawersPs6",
                }
            }

        },
         {
            "Monster6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(-1, 2, 4),
                Rotate6 = new Vector3(30, -5, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "RoomBack6",
                }
            }

        },
         {
            "MonsterHead6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(-2, 2, 5),
                Rotate6 = new Vector3(60, -200, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "Monster6",
                }
            }

        },
         {
            "Scaler6",
            new CameraPositionInfo
            {
                Position6 = new Vector3(1, 2, 4),
                Rotate6 = new Vector3(50, -15, 0),
                MoveNames6 = new MoveNames
                {
                    Back6 = "RoomBack6",
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
