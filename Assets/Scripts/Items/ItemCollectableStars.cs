using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableStars : ItemCollectableBase
{
   protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddStars();
    }
}
