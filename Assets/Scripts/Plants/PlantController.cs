using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using TMPro;

public class PlantController : MonoBehaviour
{
    [SerializeField] private PlantSO plant; 
    [Header("Debug Text")]
    [SerializeField] private TextMeshProUGUI keyPressText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI completeText;
    [SerializeField] private TextMeshProUGUI correctSequence;
    private int correctInputs = 0;
    void Awake()
    {
        Assert.IsNotNull(plant, $"The plantSO in {gameObject.name} Plant Controller is empty. Please check it");
        Assert.IsNotNull(keyPressText, "The debug keypress text is missing");
        Assert.IsNotNull(scoreText, "The debug score text is missing");
        Assert.IsNotNull(completeText, "The debug completion text is missing");
        Assert.IsNotNull(correctSequence, "The debug sequence text is missing");
        
        correctSequence.text = "Correct Sequence : \n";
        for(int i = 0 ; i < plant.noteSequence.Length; i++){
            correctSequence.text += plant.noteSequence[i] + " ";
        }
    }

    public void checkInput(DirectionEnum dir){
        keyPressText.text = $"Pressed: {dir}";
        if(plant.noteSequence.Length <= correctInputs) {
            return;
        }
        if(plant.noteSequence[correctInputs] == dir){
            correctInputs++;
        } else {
            if(plant.noteSequence[0] == dir){
                completeText.text = $"A combo is in progress for {plant.name}";
                correctInputs = 1;
            } else {
                completeText.text = $"You pressed the wrong input for {plant.name}";
                correctInputs = 0;
            }   
        }
        if(correctInputs==plant.noteSequence.Length){
            completeText.text = $"{plant.name} is done growing";
            keyPressText.gameObject.SetActive(false);
           scoreText.gameObject.SetActive(false);
        }

        scoreText.text = $"Correct # {correctInputs}";
        
    }


}
