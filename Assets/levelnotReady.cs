using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelnotReady : MonoBehaviour
{
    public Animator colorChanger;

    private void Start()
    {
        colorChanger.Play("readyButton");
    }
    public void dimmidlevel()
    {
        colorChanger.Play("notReadyButton");
    }
    public void undim() 
    {
        colorChanger.Play("readyButton");
    }
}
