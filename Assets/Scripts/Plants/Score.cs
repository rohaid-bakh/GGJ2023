using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Score : MonoBehaviour
{
    private static Score _instance;
    private float score;

    static Score Instance;

    void Awake(){
        if (Instance != null){
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void updateScore (float _score){
        score = _score;
    }
    public float returnScore(){
        return score;
    }
}
