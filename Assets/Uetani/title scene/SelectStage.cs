using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject SelectUI;
    [SerializeField]
    private GameObject TitleUI;
    //public static bool flag = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Load()
    {
        //flag = true;
        SelectUI.SetActive(!SelectUI.activeSelf);
        TitleUI.SetActive(!TitleUI.activeSelf);
    }
}
