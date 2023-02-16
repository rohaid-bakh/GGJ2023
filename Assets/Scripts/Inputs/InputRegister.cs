using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class InputRegister : BeatAlert
{
    private MainInput control;
    private LevelController level;
    [SerializeField] private List<PlantController> currPlants;
    private bool timingWindow = false;

    [Header("UI images")]
    [SerializeField] private UnityEngine.UI.Image[] noteArray; // would like this moved to a different script
    [SerializeField] private Sprite[] leaves;

    [Header("UI Labels")]
    [SerializeField] private TextMeshProUGUI scoreTracker;

    private float currCompletePlants; 
    private int currNoteIndex = 0; 

    bool start = false;

    private void Awake()
    {
        
        level = GameObject.FindObjectOfType<LevelController>();
        control = new MainInput();
        control.Enable();
        control.Keyboard.Enable();
        control.Keyboard.Right.Enable();
        control.Keyboard.Right.performed += _ => AlertPlants(DirectionEnum.RIGHT);
        control.Keyboard.Left.Enable();
        control.Keyboard.Left.performed += _ => AlertPlants(DirectionEnum.LEFT);
        
    }


    private void OnEnable() {
        control.Enable();
        control.Keyboard.Enable();
        control.Keyboard.Right.Enable();
        control.Keyboard.Left.Enable();
       
        
    }

    private void OnDisable() {
        control.Keyboard.Right.Disable();
        control.Keyboard.Left.Disable();
        control.Keyboard.Disable();
        control.Disable();
    }
    public void AddPlant(PlantController plant){
        if(plant == null) return;
        currPlants.Add(plant);
    }

    public void RemovePlant(PlantController plant){
        if(plant == null) return;
        currPlants.Remove(plant);
    }
    private void AlertPlants(DirectionEnum dir)
    {
        if(currNoteIndex >= noteArray.Length){
            for(int i = 0 ; i < noteArray.Length; i++){
                noteArray[i].sprite = null;
            }
            currNoteIndex = 0;
        }
        //write function that checks that we're on beat. Do I set like. a receiver...
        if (timingWindow)
        {
            for (int i = 0; i < currPlants.Count; i++)
            {
               bool complete =  currPlants[i].checkInput(dir);
               if(complete){
                currCompletePlants++;
                //    render.DOFade(0f , 2f).OnComplete(() => Destroy(gameObject))
                SpriteRenderer plantDespawn = currPlants[i].GetComponent<SpriteRenderer>();
                Vector3 currPlantLocation = currPlants[i].transform.position;
                plantDespawn.DOFade(0f , 0.75f).OnComplete(() => Destroy(plantDespawn.gameObject));// remove thing Off Screen
                 level.SpawnNewOne(1f, currPlantLocation); // add a delay

               }
            }
            if(dir == DirectionEnum.LEFT){
                noteArray[currNoteIndex].sprite = leaves[0];
            } else {
                noteArray[currNoteIndex].sprite = leaves[1];
            }
             
        }
        else
        {
            for (int i = 0; i < currPlants.Count; i++)
            {
                currPlants[i].checkInput(DirectionEnum.NONE);
            }
             noteArray[currNoteIndex].sprite = leaves[2];
        }
        scoreTracker.text = $"{currCompletePlants}";
        currNoteIndex++;
       
    }


    public override void AlertCorrectFrame(bool isframe)
    {
        timingWindow = isframe;
        OnFinishProcessing.Invoke();
    }
}
