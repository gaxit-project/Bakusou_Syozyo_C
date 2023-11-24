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
		bgm = GameObject.Find("/Canvas/Panel/Slider_BGM").GetComponent<Slider>();
		se = GameObject.Find("/Canvas/Panel/Slider_SE").GetComponent<Slider>();
		cube2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
		// 最初に選択状態にしたいボタンの設定
		bgm.Select();
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
}