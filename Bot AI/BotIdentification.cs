using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EnumsForPreference;

public class BotIdentification : MonoBehaviour
{
    #region bot Technical Data

    bool isStarted = false;

    public Transform placeForPortableItems;
    public GameObject bag;
    public NavMeshAgent navMeshAgent;
    public GameObject meshRenderer;
    public Animator animator;
    public GameObject home;
    [SerializeField]    private GameObject targetObj;
    public Priorities prioritets;
    public ShortTermGoals shortTermGoals;
    public float distanceToTarget { get; set; }

    #endregion

    #region bot Stats

    public float money = 0;
    public float hunger = 100;
    public float healt = 100;

    public float maxHealt = 100;
    public float maxHunger = 100;

    public float concentration = 50;

    #endregion

     public void BeforeStart()
    {
        if (!isStarted)
        {
            placeForPortableItems = gameObject.transform.Find("PlaceForPortableItems");
            animator = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
            //auxiliaryMethods = new TechnicalFunctions();
        }
    }
}
