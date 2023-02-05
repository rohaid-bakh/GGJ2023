using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Plant Notes", menuName = "Plant", order = 0)]
public class PlantSO : ScriptableObject
{
    public string Name;
    public DirectionEnum[] noteSequence;
    [Range(100f, 500f)]
    public static int score;
    public Sprite[] plantGrowth; 
}
