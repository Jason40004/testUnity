using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SimonSays : MonoBehaviour

{

    public GameObject triggerButton;
    public GameObject player;

    private Animator anim;

    public int[] solution;

    public int level;

    public Boolean displaying;

    public Boolean nextGameReady;

    public IEnumerator BeginCycle()
    {
        Debug.Log("in function");
        displaying = true;
        nextGameReady = false;
        triggerButton.GetComponent<levelnotReady>().dimmidlevel();
        int n = 0;
        switch(level)
        {
            case 0:
                n = 4;
                break;
            case 1:
                n = 5;
                break;
            case 2:
                n = 6;
                break;
        }
        Debug.Log("Current n value for length of puzzle and list: " +  n);
        solution = new int[n];
        player.GetComponent<PlayerInteract>().beginAnswer(n);

        for (int i = 0; i < n; i++)
        {
            solution[i] = UnityEngine.Random.Range(1, 5);
            switch(solution[i]) {
                case 1:
                    anim.Play("yellow");
                    break;
                case 2:
                    anim.Play("blue");
                    break;
                case 3:
                    anim.Play("red");
                    break;
                case 4:
                    anim.Play("green");
                    break;
            }
            yield return new WaitForSeconds(0.5f);
            anim.Play("base");
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("over");
        displaying = false;
    }        

    public void Reset()
    {
        Debug.Log("Next level: " + level);
        nextGameReady = true;
        triggerButton.GetComponent<levelnotReady>().undim();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("base");
        level = 0;
        displaying = false;
        nextGameReady = true;
    }
}
