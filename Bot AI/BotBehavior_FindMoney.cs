using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BotBehavior : MonoBehaviour
{
    public static void FindMoney(BotIdentification bot, params GameObject[] ignore)
    {
        //добавить рекурсию вызовов чтоб при вызове этого метода вызвался этот метод но с передаваемыми параметрами уже назначенных целью обьектами
        GameObject valueStuff = TechnicalFunctions.FindNearestObjectByTag(Tags.Return(Tags.TagsNumder.Firewood), bot.gameObject, bot.concentration, ignore);

        if(valueStuff==bot.gameObject)
        {
            Debug.Log("Все обьекты рядом заняты //Добавить логику на этот случай");
            //Это будет происходить если все обьекты рядом будут находится в "ignore"
            //Добавить логику на этот случай
        }
        //лллл
        BotIdentification whoGoesThere = TechnicalFunctions.searchInInteractedObject(valueStuff);
        if (whoGoesThere == null)
        {
            bot.targetObj = valueStuff;
            BotPublicData.AddToListWithInteractedObj(valueStuff, bot);
            FrameworkOfBotAction.SetTargetForMovement(valueStuff, bot);
        }
        else
        {
            if (TechnicalFunctions.FirtsIsCloserToTheObject(whoGoesThere, Vector3.Distance(valueStuff.transform.position, bot.transform.position)))
            {
                bot.targetObj = valueStuff;
                FrameworkOfBotAction.SetTargetForMovement(valueStuff, bot);
            }
            else
            {
                GameObject[] ignoreThis = new GameObject[ignore.Length+1];
                ignoreThis[ignore.Length] = valueStuff;
                FindMoney(bot, ignoreThis);
            }
        }
    }
}
