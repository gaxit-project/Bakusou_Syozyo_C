using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveR : MonoBehaviour
{

    public float R = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (R <= 360)
        {
            transform.eulerAngles = new Vector3(R, 0, 0);
            R += 0.5f;
        }
        else
        {
            R = 0;
        }
    }
}
