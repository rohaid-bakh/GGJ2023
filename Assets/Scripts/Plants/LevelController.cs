using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//keeps track of plants to generate
//keeps track of score
//make a singleton
public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelSO level; 
    [SerializeField] private Transform[] spawnPositions;
    private int currPlant = 0;

     void Awake()
    {
        // Assert.IsNotNull(level, "The LevelSO array in Level Controller is empty. Please check it");
        //write an assertion that checks that # to spawn is less than == # of spawnPositions
        for(int i = 0; i < spawnPositions.Length; i++){
            SpawnNewOne(i, spawnPositions[i]);
        }
        currPlant = spawnPositions.Length;

    }

    public void SpawnNewOne(int plantIndex, Transform position){
     
    //    Assert.IsNotNull(level, "is null somehwow");
    //     Assert.IsNotNull(level.plantsForLevel, "is empty somehow");
       GameObject gam = Instantiate(level.plantsForLevel[plantIndex], position.position, Quaternion.identity);
    }

    
}
