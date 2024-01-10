using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MovieChange : MonoBehaviour
{
    [SerializeField] EventSystem eventsystem;

    [Header("ステージ")]
    [SerializeField] GameObject school_N;
    [SerializeField] GameObject school_H;
    [SerializeField] GameObject shop_N;
    [SerializeField] GameObject shop_H;

    [Header("ノーマルの動画")]
    [SerializeField] GameObject Normal_No1;
    [SerializeField] GameObject Normal_No2;

    [Header("ハードの動画")]
    [SerializeField] GameObject Hard_No1;
    [SerializeField] GameObject Hard_No2;

    GameObject selectedObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        selectedObj = eventsystem.currentSelectedGameObject.gameObject;

        if (selectedObj == school_N) 
        {
            Normal_No1.SetActive(true);
            Normal_No2.SetActive(false);
            Hard_No1.SetActive(false);
            Hard_No2.SetActive(false);
        }
        if (selectedObj == school_H)
        {
            Normal_No1.SetActive(false);
            Normal_No2.SetActive(false);
            Hard_No1.SetActive(true);
            Hard_No2.SetActive(false);
        }
        if (selectedObj == shop_N)
        {
            Normal_No1.SetActive(false);
            Normal_No2.SetActive(true);
            Hard_No1.SetActive(false);
            Hard_No2.SetActive(false);
        }
        if (selectedObj == shop_H)
        {
            Normal_No1.SetActive(false);
            Normal_No2.SetActive(false);
            Hard_No1.SetActive(false);
            Hard_No2.SetActive(true);
        }
    }
}
