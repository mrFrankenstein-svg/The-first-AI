using System.Collections.Generic;
using UnityEngine;

public class BotPublicData
{
    private static List<WhatItInteractsWith> interactableObjects = new List<WhatItInteractsWith>();
    private static float interactDestantion = 2;


    public static List<WhatItInteractsWith> ListWithInteractedObj()
    {
        return interactableObjects;
    }
    public static void AddToListWithInteractedObj(GameObject obj, BotIdentification bot)
    {
        WhatItInteractsWith item = new WhatItInteractsWith();
        item.bot = bot;
        item.interactedObject = obj;
        interactableObjects.Add(item);
    }
    public static void RemoveFromListWithInteractedObj(GameObject obj, BotIdentification bot)
    {
        foreach (var item in interactableObjects)
        {
            if (item.bot == bot)
            {
                interactableObjects.Remove(item);
                continue;
            }
            if (item.interactedObject == obj)
            { 
                item.bot
            }
        }
    }

    public static float InteractDestantion
    {
        get { return interactDestantion; }
    }

}
