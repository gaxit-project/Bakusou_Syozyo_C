using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMotion : MonoBehaviour
{
    [Header("‘ÎÛAnimator")]
    Animator anim;

    int tmp;
    [Header("’Š‘I”")]
    public int N = 12;
    [Header("’Š‘IŠÔ")]
    public float Interval = 10;

    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Idle");
    }

    IEnumerator Idle()
    {
        if (flag)
        {
            yield break;
        }

        flag = true;

        tmp = Random.Range(0, N);
        //Debug.Log(tmp);
        anim.SetInteger("No.",tmp);
        yield return new WaitForSeconds(Interval);
        flag = false;
    }
}
