using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opseion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject opsionUI;
    [SerializeField]
    private GameObject TitleUI;
    [SerializeField] private GameObject SousaUI;
    [SerializeField] private GameObject CreditUI;
    [SerializeField] private GameObject SoundUI;
    Slider bgm;
    Slider se;
    Button setsumei;
    Button credit;
    Button sound;
    Button cube2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void Load()
    {
        //SelectStage.flag = false;
        opsionUI.SetActive(!opsionUI.activeSelf);
        TitleUI.SetActive(!TitleUI.activeSelf);
    }

    public void Setsumei()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        SousaUI.SetActive(!SousaUI.activeSelf);
    }

    public void Modoru1()
    {
        SousaUI.SetActive(!SousaUI.activeSelf);
        opsionUI.SetActive(!opsionUI.activeSelf);
        Option();
    }

    public void Modoru2()
    {
        CreditUI.SetActive(!CreditUI.activeSelf);
        opsionUI.SetActive(!opsionUI.activeSelf);
        Option();
    }

    public void Modoru3()
    {
        SoundUI.SetActive(!SoundUI.activeSelf);
        opsionUI.SetActive(!opsionUI.activeSelf);
        Option();
    }

    public void Credit()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        CreditUI.SetActive(!CreditUI.activeSelf);
    }

    public void Sound()
    {
        opsionUI.SetActive(!opsionUI.activeSelf);
        SoundUI.SetActive(!SoundUI.activeSelf);
    }

    public void Option()
    {
        bgm = GameObject.Find("/Canvas/Panel/Slider_BGM").GetComponent<Slider>();
        se = GameObject.Find("/Canvas/Panel/Slider_SE").GetComponent<Slider>();
        cube2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        setsumei = GameObject.Find("/Canvas/Panel/sousa").GetComponent<Button>();
        credit = GameObject.Find("/Canvas/Panel/credit").GetComponent<Button>();
        sound = GameObject.Find("/Canvas/Panel/sound").GetComponent<Button>();
        bgm.Select();
    }
}
