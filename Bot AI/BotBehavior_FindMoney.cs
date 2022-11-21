using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BotBehavior : MonoBehaviour
{
    public static void FindMoney(BotIdentification bot, params GameObject[] ignore)
    {
        //�������� �������� ������� ���� ��� ������ ����� ������ �������� ���� ����� �� � ������������� ����������� ��� ����������� ����� ���������
        GameObject valueStuff = TechnicalFunctions.FindNearestObjectByTag(Tags.Return(Tags.TagsNumder.Firewood), bot.gameObject, bot.concentration, ignore);

        if(valueStuff==bot.gameObject)
        {
            Debug.Log("��� ������� ����� ������ //�������� ������ �� ���� ������");
            //��� ����� ����������� ���� ��� ������� ����� ����� ��������� � "ignore"
            //�������� ������ �� ���� ������
        }
        //����
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
