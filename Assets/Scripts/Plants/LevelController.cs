using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
//keeps track of plants to generate
//keeps track of score
//make a singleton
public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelSO level; 
    [SerializeField] private Transform[] spawnPositions;
    private InputRegister input;
    private int currPlant = 0;
    private Score updateScore;

     void Awake()
    {
        input = GameObject.FindObjectOfType<InputRegister>(true);
        updateScore = GameObject.FindObjectOfType<Score>();
        Assert.IsNotNull(input, "Missing InputRegister Script reference in scene");
        // Assert.IsNotNull(level, "The LevelSO array in Level Controller is empty. Please check it");
        //write an assertion that checks that # to spawn is less than == # of spawnPositions
        for(int i = 0; i < spawnPositions.Length; i++){
            SpawnNewOne(i, spawnPositions[i].position);
        }
    }

    public void SpawnNewOne(int plantIndex, Vector3 position){
     
    //    Assert.IsNotNull(level, "is null somehwow");
    //     Assert.IsNotNull(level.plantsForLevel, "is empty somehow");
        updateScore.updateScore(plantIndex);
        if(plantIndex >= level.plantsForLevel.Length) {
            NextLevel();
            return;
            }
       GameObject newPlant = Instantiate(level.plantsForLevel[plantIndex], position, Quaternion.identity, transform);
       input.AddPlant(newPlant.GetComponent<PlantController>());
       currPlant++;
    }

    public void SpawnNewOne(Vector2 position){
        SpawnNewOne(currPlant, position);
    }

    public void SpawnNewOne(float delaySeconds, Vector3 position){
       StartCoroutine(DelaySpawn(delaySeconds, position));
    }

    private IEnumerator DelaySpawn(float delaySeconds, Vector3 position){
        yield return new WaitForSeconds(delaySeconds);
        SpawnNewOne(position);
    }

    private void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
