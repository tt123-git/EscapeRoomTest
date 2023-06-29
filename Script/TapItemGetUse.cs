using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapItemGetUse : TapCollider
{
    public GameObject ItemImage;
    public GameObject ActivateItemImage;

    protected override void OnTap()
    {
        base.OnTap();

        if (ItemImage.activeSelf)
        {
            ItemImage.SetActive(false);
            gameObject.SetActive(false);
            ActivateItemImage.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
