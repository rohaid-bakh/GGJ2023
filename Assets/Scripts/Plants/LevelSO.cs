using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "Level", order = 0)]
public class LevelSO : ScriptableObject
{
  public GameObject[] plantsForLevel;
  public int spawnNumber;
}
