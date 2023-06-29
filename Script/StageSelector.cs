using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
   public SceneFader fader;

   public void Select(string stageName)
    {
        fader.FadeTo(stageName);
    }
        
}
