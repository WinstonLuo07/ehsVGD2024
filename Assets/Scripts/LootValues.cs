using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LootValues : MonoBehaviour
{
    public int value = 0;
    public enum LootType { Coin }
    public LootType lootType;
    public TextMeshProUGUI lootItem;

    public int updateInventory() {
        int c = Int32.Parse(lootItem.text);
        c++;
        lootItem.text = c.ToString();
        return c;
    }
}
