using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashWrong : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public IEnumerator wrongUI()
    {
        anim.Play("wrong");
        yield return new WaitForSeconds(1);
        anim.Play("default");
    }
}
