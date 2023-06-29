using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapItemUseOff : TapCollider
{
    public GameObject ItemImage;
    public GameObject[] ActiveObjects;
    public GameObject[] NonActiveObjects;

    protected override void OnTap()
    {
        base.OnTap();

        if (ItemImage.activeSelf)
        {
            ItemImage.SetActive(false);
            gameObject.SetActive(false);
            foreach (var obj in ActiveObjects)
                obj.SetActive(false);

            gameObject.SetActive(false);
            foreach (var obj in NonActiveObjects)
                obj.SetActive(true);
        }
    }
}
