using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject levelController;
    [SerializeField] private GameObject inputReader;
    [SerializeField] private AudioSource audio;
    [SerializeField] private Beats beat;
    bool levelStart = false;

    private void Awake() {
        helpMenu.SetActive(true);
        inputReader.SetActive(false);
        levelController.SetActive(false);
        audio.Pause();
        beat.enabled = false;
    }

    public void setUpGame() {
        if(!levelStart){
        helpMenu.SetActive(false);
        inputReader.SetActive(true);
        levelController.SetActive(true);
        audio.Play();
        beat.enabled = true;
        }
        levelStart = true;
    }
}
