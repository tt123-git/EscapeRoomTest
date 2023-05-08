using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager3 : MonoBehaviour
{
    public static CameraManager3 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft3;
    public GameObject ButtonRight3;
    public GameObject ButtonBack3;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position3 { get; set; } //Camer Position
        public Vector3 Rotate3 { get; set; } // Camera Degree
        public MoveNames MoveNames3 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left3 { get; set; }
        public string Right3 { get; set; }
        public string Back3 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

        {
            "Front3",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-20, 2, -28),
                Rotate3 = new Vector3(16, 180, 0),
                MoveNames3 = new MoveNames
                {
                    Left3 = "RoomLeft3",
                    Right3 = "RoomRight3",
                    Back3 = "RoomBack3",
                }
            }
        },
        {
            "RoomLeft3",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-21, 2, -29),
                Rotate3 = new Vector3(10, 90, 0),
                MoveNames3 = new MoveNames
                {
                    Left3 = "RoomBack3",
                    Right3 = "Front3",
                    Back3 = "RoomRight3",
                }
            }
        },
        {
            "RoomRight3",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-19, 2, -30),
                Rotate3 = new Vector3(10, -90, 0),
                MoveNames3 = new MoveNames
                {
                    Left3 = "Front3",
                    Right3 = "RoomBack3",
                    Back3 = "RoomLeft3",
                }
            }
        },
        {
            "RoomBack3",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-20, 2, -30),
                Rotate3 = new Vector3(10, 0, 0),
                MoveNames3 = new MoveNames
                {
                    Left3 = "RoomRight3",
                    Right3 = "RoomLeft3",
                    Back3 = "Front3",
                }
            }
        },
        {
            "Door3",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-16, 2, -31),
                Rotate3 = new Vector3(10, 180, 0),
                MoveNames3 = new MoveNames
                {
                    Back3 = "Front3", 
                }
            }
        },
        {
            "Sci-FiBox",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-17, 2, -30),
                Rotate3 = new Vector3(10, 90, 0),
                MoveNames3 = new MoveNames
                {
                    Back3 = "RoomLeft3", 
                }
            }
        },
        {
            "Sci-FiBoxOpen",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-16, 2, -31),
                Rotate3 = new Vector3(16, 80, 0),
                MoveNames3 = new MoveNames
                {
                    Back3 = "Sci-FiBox",
                }
            }
        },
        {
            "Crate",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-23, 3, -33),
                Rotate3 = new Vector3(60, 180, 0),
                MoveNames3 = new MoveNames
                {
                    Back3 = "Front3",
                }
            }
        },
        {
            "Desktop",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-22, 2, -24),
                Rotate3 = new Vector3(15, 180, 0),
                MoveNames3 = new MoveNames
                {
                    Left3 = "RoomLeft3",
                    Right3 = "RoomRight3",
                    Back3 = "RoomBack3",
                    
                }
            }
        },
        {
            "Display",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-22, 2, -25),
                Rotate3 = new Vector3(15, 180, 0),
                MoveNames3 = new MoveNames
                {
                    Back3 = "Desktop",
                }
            }
        },
        {
            "Drawer",
            new CameraPositionInfo
            {
                Position3 = new Vector3(-23, 1, -25),
                Rotate3 = new Vector3(15, 180, 0),
                MoveNames3 = new MoveNames
                {
                    Back3 = "Desktop",
                }
            }
        },

    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Front3");

        ButtonBack3.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames3.Back3);
        });
        ButtonLeft3.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames3.Left3);
        });
        ButtonRight3.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames3.Right3);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position3;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate3);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames3.Back3 == null)
            ButtonBack3.SetActive(false);
        else ButtonBack3.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames3.Left3 == null)
            ButtonLeft3.SetActive(false);
        else ButtonLeft3.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames3.Right3 == null)
            ButtonRight3.SetActive(false);
        else ButtonRight3.SetActive(true);
    }
}
