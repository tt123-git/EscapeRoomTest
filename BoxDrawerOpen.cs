using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrawerOpen : TapCollider
{
    public GameObject[] ActiveObjects;

    protected override void OnTap()
    {
        base.OnTap();

        gameObject.SetActive(false);
        foreach (var obj in ActiveObjects)
            obj.SetActive(true);
    }
}
