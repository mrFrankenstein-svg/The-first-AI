using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TechnicalFunctions
{
    
    //������� ������ �� ���� "tag" � ������� "radius" �� ������� "center" ����� box collider ��� mesh collider � ���������� ���.
    //���� �� ������� ������- ���������� null

    //Finds an object by the tag "tag" in the radius "radius" from the object "center" by box collider or mesh collider and returns it.
    //If it doesn't find anything, it returns null
    public static GameObject FindNearestObjectByTag(string tag, GameObject centre, float radius, params GameObject[] ignore)
    {
        GameObject nearestObject = null;
        float magnitude = 0;
        List<GameObject> tagedObjekts = new List<GameObject>();

        Collider[] hitColliders = Physics.OverlapSphere(centre.transform.position, radius);

        foreach (var item in hitColliders)
        {
            if(item.gameObject.tag== tag)
                tagedObjekts.Add(item.gameObject);
        }

        foreach (var item in tagedObjekts)
        {
            bool match = false;
            foreach (var obj in ignore)
            {
                if (item == obj)
                    match = true;
            }
            
            if (match==false)
            {
                if (magnitude == 0 || Vector3.Distance(item.transform.position, centre.transform.position) < magnitude)
                {
                    magnitude = Vector3.Distance(item.transform.position, centre.transform.position);
                    nearestObject = item;
                }
            }
        }
        if (tagedObjekts.Count != ignore.Length)
            return nearestObject;
        else
            return centre;
    }

    //�������� ������ � ���� � ������������, � ������� ����� ����� ������.
    //���� �������- ���������� ������ �� ��������� ����������. ���� �� �������- ���������� null.

    //Gets an object and a sheet with containers in which it needs to find the object.
    //If it finds it, it returns a reference to the container instance. If it doesn't find it, it returns null.
    public static BotIdentification searchInInteractedObject(GameObject searchThis)
    {
        List<WhatItInteractsWith> list = BotPublicData.ListWithInteractedObj();
        foreach (var item in list)
        {
            if (item.interactedObject == searchThis)
                return item.bot;
        }
        return null;
    }


    public static void AnomationOfMove(BotIdentification bot)
    {
        if (bot.animator.GetBool("run") != bot.navMeshAgent.hasPath)
        {
            bot.animator.SetBool("run", bot.navMeshAgent.hasPath);
        }
    }

    public static bool FirtsIsCloserToTheObject(BotIdentification second, float botDistance)
    {
        if (second.distanceToTarget > botDistance)
            return true;
        else
            return false;
    }



    //public static void Overlap(ref List<GameObject> col)
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, concentration);

    //    foreach (var item in hitColliders)
    //    {
    //        col.Add(item.gameObject);
    //    }
    //}
}
