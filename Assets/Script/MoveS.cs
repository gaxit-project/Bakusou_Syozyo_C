using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveS : MonoBehaviour
{
    public float Sx = 1;
    public float Sy = 1;
    public float Sz = 1;

    public float V;

    public bool flag = true;
    public bool flagx = true;
    public bool flagy = true;
    public bool flagz = true;

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
