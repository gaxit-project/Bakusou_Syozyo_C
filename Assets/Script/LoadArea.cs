using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadArea : MonoBehaviour
{
    public GameObject[] LoadObject;
    public static bool invasion =false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < LoadObject.Length; i++)
        {
            if (!invasion)
            {
                LoadObject[i].SetActive(false);
            }
            else
            {
                LoadObject[i].SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("N“ü¬Œ÷");
            invasion = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("—£’E¬Œ÷");
            invasion = false;
        }
    }
}
