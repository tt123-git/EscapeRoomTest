using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager9 : MonoBehaviour
{
    public static CameraManager9 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft9;
    public GameObject ButtonRight9;
    public GameObject ButtonBack9;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position9 { get; set; } //Camer Position
        public Vector3 Rotate9 { get; set; } // Camera Degree
        public MoveNames MoveNames9 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left9 { get; set; }
        public string Right9 { get; set; }
        public string Back9 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

         {
            "Door9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(0, 2, -7),
                Rotate9 = new Vector3(10, 0, 0),
                MoveNames9 = new MoveNames
                {
                    Left9 = "RoomLeft9",
                    Right9 = "RoomRight9",
                    Back9 = "RoomBack9",
                }
            }

        },
        {
            "RoomLeft9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(0, 2, -7),
                Rotate9 = new Vector3(10, -90, 0),
                MoveNames9 = new MoveNames
                {
                    Left9 = "RoomBack9",
                    Right9 = "Door9",
                    Back9 = "RoomRight9",
                }
            }

        },
        {
            "FullMetal9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(-3, 2, -8),
                Rotate9 = new Vector3(60, -180, 0),
                MoveNames9 = new MoveNames
                {
                    Back9 = "RoomLeft9",
                }
            }

        },
        {
            "RoomRight9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(0, 2, -7),
                Rotate9 = new Vector3(10, 90, 0),
                MoveNames9 = new MoveNames
                {
                    Left9 = "Door9",
                    Right9 = "RoomBack9",
                    Back9 = "RoomLeft9",
                }
            }

        },
        {
            "Box9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(2, 1, -6),
                Rotate9 = new Vector3(20, 100, 0),
                MoveNames9 = new MoveNames
                {
                    Back9 = "RoomRight9",
                }
            }

        },
        {
            "Swords9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(2, 2, -5),
                Rotate9 = new Vector3(-5, 105, 0),
                MoveNames9 = new MoveNames
                {
                    Back9 = "RoomRight9",
                }
            }

        },
        {
            "RoomBack9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(0, 2, -7),
                Rotate9 = new Vector3(12, 180, 0),
                MoveNames9 = new MoveNames
                {
                    Left9 = "RoomRight9",
                    Right9 = "RoomLeft9",
                    Back9 = "Door9",
                }
            }

        },
        {
            "Smith9",
            new CameraPositionInfo
            {
                Position9 = new Vector3(0, 2, -9),
                Rotate9 = new Vector3(35, 180, 0),
                MoveNames9 = new MoveNames
                {
                    Back9 = "RoomBack9",
                }
            }

        },
    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Door9");

        ButtonBack9.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames9.Back9);
        });
        ButtonLeft9.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames9.Left9);
        });
        ButtonRight9.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames9.Right9);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position9;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate9);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames9.Back9 == null)
            ButtonBack9.SetActive(false);
        else ButtonBack9.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames9.Left9 == null)
            ButtonLeft9.SetActive(false);
        else ButtonLeft9.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames9.Right9 == null)
            ButtonRight9.SetActive(false);
        else ButtonRight9.SetActive(true);
    }
}
