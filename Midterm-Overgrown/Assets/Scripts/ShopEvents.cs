using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ShopEvents
{
    public static event EventHandler RefreshCards;

    public static void InvokeRefreshCards()
    {
        RefreshCards(null, EventArgs.Empty);
    }
}
