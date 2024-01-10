using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIコンポーネントの使用
using UnityEngine.EventSystems;//イベントシステムの使用

public class menu : MonoBehaviour
{
	Button cube;
	Button sphere;
	Button cylinder;
	Button cube2;
    Button normal;
    Button hard;
    Button modoru;
    Button setsumei;
    Button credit;
    Button sound;
    Slider bgm;
	Slider se;

	void Start()
    {
		// ボタンコンポーネントの取得
		cube = GameObject.Find("/Canvas/Title_Panel/Button1").GetComponent<Button>();
		sphere = GameObject.Find("/Canvas/Title_Panel/Button2").GetComponent<Button>();
		cylinder = GameObject.Find("/Canvas/Title_Panel/Button3").GetComponent<Button>();
		// 最初に選択状態にしたいボタンの設定
		cube.Select();
        //Time.timeScale = 0f;
    }

    public void Opusion()
	{
		cube2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
        setsumei = GameObject.Find("/Canvas/Panel/sousa").GetComponent<Button>();
        credit = GameObject.Find("/Canvas/Panel/credit").GetComponent<Button>();
        sound = GameObject.Find("/Canvas/Panel/sound").GetComponent<Button>();
        // 最初に選択状態にしたいボタンの設定
        sound.Select();
	}
	public void Taitol()
	{
		//Application.LoadLevel("titel");
		// ボタンコンポーネントの取得
		cube = GameObject.Find("/Canvas/Title_Panel/Button1").GetComponent<Button>();
		sphere = GameObject.Find("/Canvas/Title_Panel/Button2").GetComponent<Button>();
		cylinder = GameObject.Find("/Canvas/Title_Panel/Button3").GetComponent<Button>();
		// 最初に選択状態にしたいボタンの設定
		cube.Select();
	}
    public void SelectStage()
    {
        normal = GameObject.Find("/Canvas/Select/Normal").GetComponent<Button>();
        hard = GameObject.Find("/Canvas/Select/Hard").GetComponent<Button>();
        modoru = GameObject.Find("/Canvas/Select/Modoru").GetComponent<Button>();
        normal.Select();
    }
    public void Sousa()
    {
        modoru = GameObject.Find("/Canvas/Sousa/Modoru").GetComponent<Button>();
        modoru.Select();
    }
    public void Credit()
    {
        modoru = GameObject.Find("/Canvas/Credit/Modoru").GetComponent<Button>();
        modoru.Select();
    }
    public void Sound()
    {
        bgm = GameObject.Find("/Canvas/Sound/Slider_BGM").GetComponent<Slider>();
        se = GameObject.Find("/Canvas/Sound/Slider_SE").GetComponent<Slider>();
        modoru = GameObject.Find("/Canvas/Sound/Modoru").GetComponent<Button>();
        bgm.Select();
    }
}