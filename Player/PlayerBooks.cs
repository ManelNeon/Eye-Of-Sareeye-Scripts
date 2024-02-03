using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBooks : MonoBehaviour
{
    [Header("Books")]

    [SerializeField] GameObject beastiary;
    [SerializeField] GameObject maid;
    [SerializeField] GameObject marmacEntity;
    [SerializeField] GameObject marmacBio;
    [SerializeField] GameObject map;

    [HideInInspector] public bool hasBeastiary;
    [HideInInspector] public bool hasMaid;
    [HideInInspector] public bool hasMarmacEntity;
    [HideInInspector] public bool hasMarmacBio;
    [HideInInspector] public bool hasMap;
    void Update()
    {
        
    }
}
