using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveS : MonoBehaviour
{
    float Sx = 1, Sy = 1;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (Sy <= 5)
            {
                Sy += 0.01f;
                transform.localScale = new Vector3(Sx, Sy, 1);

                if (Sx > 1)
                {
                    Sx -= 0.01f;
                    transform.localScale = new Vector3(Sx, Sy, 1);
                }
            }
            else
            {
                flag = false;
            }
        }

        if (!flag)
        {
            if (Sx <= 5)
            {
                Sx += 0.01f;
                transform.localScale = new Vector3(Sx, Sy, 1);

                if (Sy > 1)
                {
                    Sy -= 0.01f;
                    transform.localScale = new Vector3(Sx, Sy, 1);
                }
            }
            else
            {
                flag = true;
            }
        }
    }
}
