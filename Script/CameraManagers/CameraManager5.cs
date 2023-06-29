using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager5 : MonoBehaviour
{
    public static CameraManager5 Instance { get; private set; }

    public string CurrentPositionName { get; private set; } //Current Camera position

    public GameObject ButtonLeft5;
    public GameObject ButtonRight5;
    public GameObject ButtonBack5;


    private class CameraPositionInfo //Camera position Info class
    {
        public Vector3 Position5 { get; set; } //Camer Position
        public Vector3 Rotate5 { get; set; } // Camera Degree
        public MoveNames MoveNames5 { get; set; } // Button Directions
    }

    private class MoveNames // Button Direction class
    {
        public string Left5 { get; set; }
        public string Right5 { get; set; }
        public string Back5 { get; set; }
    }

    private Dictionary<string, CameraPositionInfo> _CameraPositionInfos = new Dictionary<string, CameraPositionInfo>
    {

         {
            "Front5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 2, 0),
                Rotate5 = new Vector3(10, -90, 0),
                MoveNames5 = new MoveNames
                {
                    Left5 = "RoomLeft5",
                    Right5 = "RoomRight5",
                    Back5 = "RoomBack5",
                }
            }

        },
         {
            "Door5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 2, -1),
                Rotate5 = new Vector3(10, -90, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "Front5",
                }
            }

        },
         {
            "RoomLeft5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-3, 2, 0),
                Rotate5 = new Vector3(15, -180, 0),
                MoveNames5 = new MoveNames
                {
                    Left5 = "RoomBack5",
                    Right5 = "Front5",
                    Back5 = "RoomRight5",
                }
            }

        },
         {
            "Wood5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-3, 2, -1),
                Rotate5 = new Vector3(45, 150, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "RoomLeft5",
                }
            }

        },
         {
            "WoodBreak5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-3, 2, -1),
                Rotate5 = new Vector3(45, 150, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "Wood5",
                }
            }

        },
          {
            "RoomRight5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 2, -1),
                Rotate5 = new Vector3(15, 0, 0),
                MoveNames5 = new MoveNames
                {
                    Left5 = "Front5",
                    Right5 = "RoomBack5",
                    Back5 = "RoomLeft5",
                }
            }

        },
          {
            "UnderTheBed5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 1, 2),
                Rotate5 = new Vector3(35, -120, 0),
                MoveNames5 = new MoveNames
                {
                    
                    Back5 = "RoomRight5",
                }
            }

        },
         {
            "RoomBack5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-3, 2, 0),
                Rotate5 = new Vector3(15, 90, 0),
                MoveNames5 = new MoveNames
                {
                    Left5 = "RoomRight5",
                    Right5 = "RoomLeft5",
                    Back5 = "Front5",
                }
            }

        },
          {
            "Closet5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 2, 1),
                Rotate5 = new Vector3(30, 90, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "RoomBack5",
                }
            }

        },
         {
            "ClosetOpen5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 2, 1),
                Rotate5 = new Vector3(30, 90, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "Closet5",
                }
            }

        },
        {
            "TreasureBox5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-1, 1, 1),
                Rotate5 = new Vector3(35, 30, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "RoomBack5",
                }
            }

        },
        {
            "Desk5",
            new CameraPositionInfo
            {
                Position5 = new Vector3(-2, 2, -1),
                Rotate5 = new Vector3(45, 110, 0),
                MoveNames5 = new MoveNames
                {
                    Back5 = "RoomBack5",
                }
            }

        },


    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Front5");

        ButtonBack5.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames5.Back5);
        });
        ButtonLeft5.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames5.Left5);
        });
        ButtonRight5.GetComponent<Button>().onClick.AddListener(() =>
        {
            ChangeCameraPosition(_CameraPositionInfos[CurrentPositionName].MoveNames5.Right5);
        });
    }

    public void ChangeCameraPosition(string positionName) //Camera Movement
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfos[CurrentPositionName].Position5;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfos[CurrentPositionName].Rotate5);

        UpdateButtonActive();
    }

    private void UpdateButtonActive()
    {
        if (_CameraPositionInfos[CurrentPositionName].MoveNames5.Back5 == null)
            ButtonBack5.SetActive(false);
        else ButtonBack5.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames5.Left5 == null)
            ButtonLeft5.SetActive(false);
        else ButtonLeft5.SetActive(true);
        if (_CameraPositionInfos[CurrentPositionName].MoveNames5.Right5 == null)
            ButtonRight5.SetActive(false);
        else ButtonRight5.SetActive(true);
    }
}
