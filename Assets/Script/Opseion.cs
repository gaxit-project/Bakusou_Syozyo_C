using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opseion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject opsionUI;
    [SerializeField]
    private GameObject TitleUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Load()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        TitleUI.SetActive(!TitleUI.activeSelf);
    }
}
