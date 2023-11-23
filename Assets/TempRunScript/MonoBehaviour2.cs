using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class menu2 : MonoBehaviour
{
	Button b1;
	Button b2;
	void Start()
	{
        //Time.timeScale = 0f;
        b1 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
		b2 = GameObject.Find("/Canvas/Panel/Button1").GetComponent<Button>();
		// 最初に選択状態にしたいボタンの設定
		b1.Select();
	}

	
}