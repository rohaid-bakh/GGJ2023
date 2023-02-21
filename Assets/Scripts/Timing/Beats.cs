using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Beats : MonoBehaviour
{
    [SerializeField] private int BPM; 
    [SerializeField] private BeatAlert[] observing;
    private float frameCount;
    private float counter;
    private float currNumBeats = 1;
    [SerializeField] private float frameLeniancy;
    [SerializeField] private TextMeshProUGUI debugBeat;

    void Awake()
    {
         Application.targetFrameRate = 60;
        if (BPM<=0){ // EXAMPLE
            BPM = 200;
        } 
        
        frameCount = (60f*60f)/(float)BPM; // total amount of frames (60 per second * # seconds per mnute / total BPM)
        currNumBeats = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float perfFrameCount = currNumBeats * frameCount;
        float lowestFrameCount = (perfFrameCount - frameLeniancy >= 0) ? (perfFrameCount - frameLeniancy) : 0;
        float highestFrameCount = perfFrameCount + frameLeniancy;
     
        if(counter != 0 && (counter >= lowestFrameCount && counter <= highestFrameCount)) 
        {
            debugBeat.text = "On";
            debugBeat.color = Color.green;
            for(int i = 0 ; i <observing.Length; i++){
                observing[i].AlertCorrectFrame(true);
            }
        } else {
             debugBeat.text = "Off";
            debugBeat.color = Color.red;
              for(int i = 0 ; i <observing.Length; i++){
                observing[i].AlertCorrectFrame(false);
            }
        }
        if (counter >= highestFrameCount){
            currNumBeats++;
        }
        counter++;
}
}