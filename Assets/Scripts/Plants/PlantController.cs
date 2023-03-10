using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using TMPro;
using DG.Tweening;

public class PlantController : MonoBehaviour
{
    [SerializeField] private PlantSO plant; 
    [Header("Debug Text")]
    [SerializeField] private TextMeshProUGUI keyPressText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI completeText;
    [SerializeField] private TextMeshProUGUI correctSequence;
    [SerializeField] private SpriteRenderer render;

    private int correctInputs = 0;
    private bool complete = false; 

    void Awake()
    {
        // Assert.IsNotNull(plant, $"The plantSO in {gameObject.name} Plant Controller is empty. Please check it");
        // Assert.IsNotNull(keyPressText, "The debug keypress text is missing");
        // Assert.IsNotNull(scoreText, "The debug score text is missing");
        // Assert.IsNotNull(completeText, "The debug completion text is missing");
        // Assert.IsNotNull(correctSequence, "The debug sequence text is missing");
        
        // correctSequence.text = "Correct Sequence : \n";
        // for(int i = 0 ; i < plant.noteSequence.Length; i++){
        //     correctSequence.text += plant.noteSequence[i] + " ";
        // }
        render = GetComponent<SpriteRenderer>();
    }

    public bool checkInput(DirectionEnum dir){
        if(complete) return false;

        if(plant.noteSequence.Length <= correctInputs) { // why is it here?
            return false;
        }
        if(plant.noteSequence[correctInputs] == dir){
            correctInputs++;
            render.sprite = plant.plantGrowth[correctInputs];
        } else {
            if(plant.noteSequence[0] == dir){
                correctInputs = 1;
                 render.sprite = plant.plantGrowth[correctInputs];
            } else {
                correctInputs = 0;
                 render.sprite = plant.plantGrowth[correctInputs];
            }   
        }
        if(correctInputs==plant.noteSequence.Length){
           complete = true;
           return true;
        }

        return false;
        
    }


}
