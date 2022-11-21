using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumsForPreference;

public partial class BotBehavior : MonoBehaviour
{
    public static void BotAction(BotIdentification bot)
    {
        if (bot.targetObj.tag == Tags.Return(Tags.TagsNumder.HeallPlace))
        {
            bot.healt = bot.maxHealt;
            bot.prioritets = Priorities.None;
            bot.shortTermGoals = ShortTermGoals.None;
        }
        else if (bot.targetObj.tag == Tags.Return(Tags.TagsNumder.Home))
        {
            if (bot.shortTermGoals != ShortTermGoals.Stay)
            {
                FrameworkOfBotAction.GetIn(bot);
                FrameworkOfBotAction.Healing(Time.deltaTime, bot);
            }
            else
            {
                FrameworkOfBotAction.Healing(Time.deltaTime, bot);
            }

            if (bot.healt >= bot.maxHealt)
            {
                bot.healt = bot.maxHealt;
                bot.shortTermGoals = ShortTermGoals.None;
                bot.prioritets = Priorities.None;
                FrameworkOfBotAction.GetOut(bot);
            }
        }
        else if (bot.targetObj.tag == Tags.Return(Tags.TagsNumder.Firewood))
        {
            bot.bag = bot.targetObj;
            Destroy(bot.bag.GetComponent<MeshCollider>());
            bot.bag.transform.SetParent(bot.placeForPortableItems);
            bot.bag.transform.position = bot.placeForPortableItems.position;
            bot.bag.transform.rotation = bot.placeForPortableItems.rotation;
            bot.targetObj = FrameworkOfBotAction.FindePlaceForSell(bot);
            FrameworkOfBotAction.SetTargetForMovement(bot.targetObj, bot);
        }
        else if (bot.targetObj.tag == Tags.Return(Tags.TagsNumder.PlaceForSell))
        {
            bot.money++;
            Destroy(bot.bag);
            bot.prioritets = Priorities.None;
            bot.shortTermGoals = ShortTermGoals.None;
        }
        //GlobalEventManager.Action();
    }
}
