using System.Collections.Generic;
using UnityEngine;
using EnumsForPreference;

public class BotMovementController : MonoBehaviour
{
    #region All Argunents

    public List<BotIdentification> listOfBots = new List<BotIdentification>();
    public int botCounter = 0;


    #endregion

   
    private void Update()
    {
        if (listOfBots.Count != 0 && botCounter <= listOfBots.Count)
            SearchUpdate(listOfBots[botCounter]);

        botCounter++;

        if (botCounter >= listOfBots.Count)
            botCounter = 0;
    }
    
    //просто затычка чтоб что-то вызывало нужный метод
    //потом переименовать
    private void SearchUpdate(BotIdentification bot)
    {
        if (bot.prioritets == Priorities.None)
        {
            FrameworkOfBotAction.FindTopPriority(bot);
        }
        if (bot.shortTermGoals == ShortTermGoals.None)
        {
            FrameworkOfBotAction.FindMediumPriority(bot);
        }

        if (bot.shortTermGoals == ShortTermGoals.GoTo)
        {
            bot.distanceToTarget = Vector3.Distance(bot.targetObj.transform.position, bot.transform.position);

            if (bot.distanceToTarget <= BotPublicData.InteractDestantion)
            {
                bot.navMeshAgent.destination = transform.position;
                bot.shortTermGoals = ShortTermGoals.None;
            }
        }

        if (bot.shortTermGoals == ShortTermGoals.Interact)
        {
           BotBehavior.BotAction(bot);
        }

        TechnicalFunctions.AnomationOfMove(bot);
    }
}
