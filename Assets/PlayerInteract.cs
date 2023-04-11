using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Boolean inrange;

    public GameObject board;

    public GameObject door;

    public GameObject scoreboard;

    public GameObject wrongx;

    private SimonSays simon;

    public int[] playerselection;

    private int i;

    private int j;

    private Boolean pause;

    public Boolean answering;

    public Boolean rRange;

    public Boolean gRange;

    public Boolean bRange;

    public Boolean yRange;
    
    // Start is called before the first frame update
    void Start()
    {
        inrange = false;
        pause = false;
        simon = board.GetComponent<SimonSays>();
        answering = false;
        rRange = false;
        gRange = false; 
        bRange = false; 
        yRange = false;
        i = 0;
        j = int.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && inrange && !simon.displaying && simon.nextGameReady && !pause) 
        {
            StartCoroutine (simon.BeginCycle());
        }
       if (Input.GetKeyDown(KeyCode.E) && yRange && answering && !simon.displaying && i < j && !pause)
        {
            StartCoroutine (Add(1));
        }
        if (Input.GetKeyDown(KeyCode.E) && bRange && answering && !simon.displaying && i < j && !pause)
        {
            StartCoroutine (Add(2));
        }
        if (Input.GetKeyDown(KeyCode.E) && rRange && answering && !simon.displaying && i < j && !pause)
        {
            StartCoroutine (Add(3));
        }
        if (Input.GetKeyDown(KeyCode.E) && gRange && answering && !simon.displaying && i < j && !pause)
        {
            StartCoroutine (Add(4));
        }
        if (i >= j) 
        {
            answerOver();
        }
    }

    private IEnumerator Add(int a)
    {
        pause = true;
        playerselection[i++] = a;
        GetComponent<Animator>().Play("pause");
        yield return new WaitForSeconds(0.5f);
        GetComponent<Animator>().Play("normal");
        pause = false;
    }

    private void answerOver()
    {
        answering = false;
        i = 0;
        int correctAnswers = 0;
        for (int m = 0; m < j; m++)
        {
            if (playerselection[m] == simon.solution[m])
            {
                correctAnswers++;
            }
        }
        if (correctAnswers == j)
        {
           scoreboard.GetComponent<Animator>().Play((simon.level + 1).ToString());
            if (simon.level < 2)
            {
                simon.level++;
            } else
            {
                Destroy(door);
            }
            simon.Reset();
        } else
        {
            simon.Reset();
            StartCoroutine(wrongx.GetComponent<flashWrong>().wrongUI());
        }
        j = int.MaxValue;
    }

    public void beginAnswer(int n)
    {
        playerselection = new int[n];
        i = 0;
        j = n;
        answering = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ButtonTrigger")
        {
            inrange = true;
        } else if (collision.tag == "yellowb")
        {
            yRange = true;
        } else if (collision.tag == "blueb")
        {
            bRange = true;
        } else if (collision.tag == "greenb")
        {
            gRange = true;
        } else if (collision.tag == "redb")
        {
            rRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ButtonTrigger")
        {
            inrange = false;
        }
        else if (collision.tag == "yellowb")
        {
            yRange = false;
        }
        else if (collision.tag == "blueb")
        {
            bRange = false;
        }
        else if (collision.tag == "greenb")
        {
            gRange = false;
        }
        else if (collision.tag == "redb")
        {
            rRange = false;
        }
    }

}
