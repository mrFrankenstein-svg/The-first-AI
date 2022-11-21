using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public enum TagsNumder 
    {
        Empty,
        HeallPlace,
        Home,
        OtherBot,
        PlaceForSell,
        PlaceForBuy,
        Firewood
    }

    static string[] tags = new string[] 
    {
        "Untagged",
        "Healt+",
        "Home",
        "Person",
        "Sell",
        "Buy",
        "Firewood"
    };

    public static string Return(TagsNumder num)
    {
        return tags[(int)num];
    }
}
