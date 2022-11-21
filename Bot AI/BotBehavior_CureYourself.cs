using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BotBehavior : MonoBehaviour
{
    public static void CureYourself(BotIdentification bot)
    {
        GameObject healtPlace = TechnicalFunctions.FindNearestObjectByTag(Tags.Return(Tags.TagsNumder.HeallPlace), bot.gameObject, bot.concentration);
        if (healtPlace != null)
        {
            bot.targetObj = healtPlace;
            FrameworkOfBotAction.SetTargetForMovement(healtPlace, bot);
        }
        else
        {
            bot.targetObj = bot.home;
            FrameworkOfBotAction.SetTargetForMovement(bot.home, bot);
        }
    }
}
