using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextStars;
    

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;

    }

    public static void UpdateTextStars(string s)
    {
        Instance.uiTextStars.text = s;

    }
}
