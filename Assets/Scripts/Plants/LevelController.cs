using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//keeps track of plants to generate
//keeps track of score
//make a singleton
public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelSO[] levels; 

     void Awake()
    {
        Assert.IsNotNull(levels, "The LevelSO array in Level Controller is empty. Please check it");

    }

    
}
