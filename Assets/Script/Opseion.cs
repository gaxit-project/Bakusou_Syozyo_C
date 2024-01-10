using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opseion : MonoBehaviour
{
    [Header("表示されるUI")]
    [SerializeField] private GameObject TitleUI;
    [SerializeField] private GameObject SelectUI;
    [SerializeField] private GameObject opsionUI;
    [SerializeField] private GameObject SoundUI;
    [SerializeField] private GameObject SousaUI;
    [SerializeField] private GameObject CreditUI;

    [Header("選択されるボタン")]
    public Button title;
    public Button opsion;
    public Button select;
    public Slider sound;
    public Button sousa;
    public Button credit;

    private void Start()
    {
        title.Select();
    }


    public void Load_Opsion()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        TitleUI.SetActive(!TitleUI.activeSelf);
        opsion.Select();
    }

    public void Load_Sousa()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        SousaUI.SetActive(!SousaUI.activeSelf);
        sousa.Select();
    }

    public void Load_Credit()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        CreditUI.SetActive(!CreditUI.activeSelf);
        credit.Select();
    }

    public void Load_Sound()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        SoundUI.SetActive(!SoundUI.activeSelf);
        sound.Select();
    }

    public void Load_Select()
    {
        SelectUI.SetActive(!SelectUI.activeSelf);
        TitleUI.SetActive(!TitleUI.activeSelf);
        select.Select();
    }

    public void Modoru_Suosa()
    {
        SousaUI.SetActive(!SousaUI.activeSelf);
        opsionUI.SetActive(!opsionUI.activeSelf);
        opsion.Select();
    }

    public void Modoru_Credit()
    {
        CreditUI.SetActive(!CreditUI.activeSelf);
        opsionUI.SetActive(!opsionUI.activeSelf);
        opsion.Select();
    }

    public void Modoru_Sound()
    {
        SoundUI.SetActive(!SoundUI.activeSelf);
        opsionUI.SetActive(!opsionUI.activeSelf);
        opsion.Select();
    }

    public void Modoru_Title()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        TitleUI.SetActive(!TitleUI.activeSelf);
        title.Select();
    }
}
