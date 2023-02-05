using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BeatAlert : MonoBehaviour
{
   public UnityEvent OnFinishProcessing = new UnityEvent();
    public abstract void AlertCorrectFrame(bool isframe);
}
