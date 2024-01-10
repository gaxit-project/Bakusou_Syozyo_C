using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public float Vp = 5, Vr = 100;
    public float x, y;

    //コントローラーのボタン取得
    float L_axisH = 0.0f;
    float L_axisV = 0.0f;
    float R_axisH = 0.0f;
    float R_axisV = 0.0f;
    float T_axis  = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        /*
        CharaSelect.select.Select();
        //x = transform.rotation.x;
        //y = transform.rotation.y;
        x = 0;
        y = 180;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Lスティック読み込み
        L_axisH = Input.GetAxisRaw("L_Stick_H");
        L_axisV = Input.GetAxisRaw("L_Stick_V");
        //Rスティック読み込み
        R_axisH = Input.GetAxisRaw("R_Stick_H");
        R_axisV = Input.GetAxisRaw("R_Stick_V");
        //トリガー読み込み
        T_axis = Input.GetAxisRaw("L_R_Trigger");

        Cameracontroll();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SelectMachine")
        {
            CharaSelect.UI.SetActive(true);
            CharaSelect.select.Select();
        }
        if (other.gameObject.name == "Gate")
        {
            SceneManager.LoadScene("titel", LoadSceneMode.Single);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SelectMachine")
        {
            CharaSelect.UI.SetActive(false);
        }
    }


    void Cameracontroll()
    {
        //移動
        transform.Translate(Vector3.up * Time.deltaTime * T_axis * Vp);
        transform.Translate(Vector3.forward * Time.deltaTime * L_axisV * Vp);
        transform.Translate(Vector3.right * Time.deltaTime * L_axisH * Vp);

        //回転
        x += Time.deltaTime * R_axisV * -Vr;
        y += Time.deltaTime * R_axisH * Vr;
        transform.rotation = Quaternion.Euler(x, y, 0);
    }


    public void MapPosi()
    {
        if (CharaSelect.Mapnumber == 0)
        {
            transform.position = new Vector3(0, 0.8f, 0);
        }
        else
        {
            transform.position = new Vector3(500, 0.8f, 0);
        }
    }
}
