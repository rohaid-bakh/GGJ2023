using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRegister : MonoBehaviour
{
    private MainInput control;
    [SerializeField] private PlantController[] currPlants;

    private void Awake(){
        control = new MainInput();
        control.Enable();
        control.Keyboard.Enable();
        control.Keyboard.Right.Enable();
        control.Keyboard.Right.performed += _ => AlertPlants(DirectionEnum.RIGHT);
        control.Keyboard.Left.Enable();
        control.Keyboard.Left.performed += _ => AlertPlants(DirectionEnum.LEFT);

    }

    private void AlertPlants(DirectionEnum dir){
        for(int i = 0; i < currPlants.Length; i++){
            currPlants[i].checkInput(dir);
        }
    }
}
