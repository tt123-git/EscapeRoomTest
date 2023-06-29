using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintShowup : MonoBehaviour
{
    public GameObject hint;
    

    public void hintTap()
    {
        hint.SetActive(true);
    }

    public void buttonClose()
    {
        hint.SetActive(false);
    }

   

}
