using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveR : MonoBehaviour
{
    [Header("スタート地点")]
    public float Rx = 0;
    public float Ry = 0;
    public float Rz = 0;

    [Header("ゴール地点")]
    public float RxG;
    public float RyG;
    public float RzG;

    [Header("回転速度")]
    public float Vx;
    public float Vy;
    public float Vz;

    [Header("ループ")]
    public bool infinity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rx = kaiten(Rx, RxG, Vx);
        Ry = kaiten(Ry, RyG, Vy);
        Rz = kaiten(Rz, RzG, Vz);
        transform.eulerAngles = new Vector3(Rx, Ry, Rz);
    }

    float kaiten(float R,float RG,float V)
    {
        if (R < RG)
        {
            R += V;
        }
        else if(infinity)
        {
            R = 0;
        }
        
        return R;
    }
}
