using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    private float score; 
    [SerializeField] private TextMeshProUGUI scorescreen;

    void Awake()
    {
        score = GameObject.FindObjectOfType<Score>().returnScore();
        scorescreen.text = $"You've nourished a total of {score} plants through the melodious sounds you've played.";
    }
}
