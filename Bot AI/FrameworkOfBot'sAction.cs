using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumsForPreference;

public static class FrameworkOfBotAction 
{
    public static void FindMediumPriority(BotIdentification bot)
    {
        if (bot.prioritets != Priorities.None)
        {
            if (bot.distanceToTarget <= BotPublicData.InteractDestantion)
            {
                bot.shortTermGoals = ShortTermGoals.Interact;
                BotBehavior.BotAction(bot);
            }
            else
            {
                bot.shortTermGoals = ShortTermGoals.GoTo;
            }
        }
    }
    public static void FindTopPriority(BotIdentification bot)
    {
        if (bot.healt <= (bot.maxHealt - (bot.maxHealt / 2)))
        {
            bot.prioritets = Priorities.Healt;
            BotBehavior.CureYourself(bot);
        }
        else if ((bot.hunger <= (bot.maxHunger - (bot.maxHunger / 2))))
        {
            bot.prioritets = Priorities.Hunger;
            BotBehavior.FeedYourself();
        }
        else
        {
            bot.prioritets = Priorities.Money;
            BotBehavior.FindMoney(bot);
        }
    }
    public static GameObject FindePlaceForSell(BotIdentification bot)
    {
        GameObject place = bot.home.transform.parent.Find("Sell").gameObject;
        return place;
    }
    public static void Healing(float healingPoints, BotIdentification bot)
    {
        if (bot.healt + healingPoints <= bot.maxHealt)
            bot.healt += healingPoints;
        else
            bot.healt = bot.maxHealt;
    }
    public static void GetIn(BotIdentification bot)
    {
        bot.meshRenderer.SetActive(false);
        bot.animator.enabled = false;
        bot.navMeshAgent.enabled = false;
    }
    public static void GetOut(BotIdentification bot)
    {
        bot.meshRenderer.SetActive(true);
        bot.animator.enabled = true;
        bot.navMeshAgent.enabled = true;
    }
    public static void SetTargetForMovement(GameObject target, BotIdentification bot)
    {
        bot.navMeshAgent.destination = target.transform.position;
        bot.shortTermGoals = ShortTermGoals.GoTo;
    }
}
