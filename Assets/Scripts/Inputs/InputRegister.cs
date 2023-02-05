using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class InputRegister : BeatAlert
{
    private MainInput control;
    [SerializeField] private PlantController[] currPlants;
    private bool timingWindow = false;

    [Header("UI images")]
    [SerializeField] private UnityEngine.UI.Image[] noteArray; // would like this moved to a different script
    [SerializeField] private Sprite[] leaves;

    private int currNoteIndex = 0; 

    private void Awake()
    {
        control = new MainInput();
        control.Enable();
        control.Keyboard.Enable();
        control.Keyboard.Right.Enable();
        control.Keyboard.Right.performed += _ => AlertPlants(DirectionEnum.RIGHT);
        control.Keyboard.Left.Enable();
        control.Keyboard.Left.performed += _ => AlertPlants(DirectionEnum.LEFT);

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
            for (int i = 0; i < currPlants.Length; i++)
            {
                currPlants[i].checkInput(dir);
            }
            if(dir == DirectionEnum.LEFT){
                noteArray[currNoteIndex].sprite = leaves[0];
            } else {
                noteArray[currNoteIndex].sprite = leaves[1];
            }
             
        }
        else
        {
            for (int i = 0; i < currPlants.Length; i++)
            {
                currPlants[i].checkInput(DirectionEnum.NONE);
            }
        }
        currNoteIndex++;
       
    }

    public override void AlertCorrectFrame(bool isframe)
    {
        timingWindow = isframe;
        OnFinishProcessing.Invoke();
    }
}
