using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "Level", order = 0)]
public class LevelSO : ScriptableObject
{
  public PlantSO[] plantsForLevel;
  public int spawnNumber;
}
