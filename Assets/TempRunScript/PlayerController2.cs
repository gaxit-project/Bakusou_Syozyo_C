using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//シーン切り替えに使用するライブラリ
using UnityEngine.SceneManagement;


public class PlayerController2 : MonoBehaviour
{
	public Animator anim;

	//左右の移動速度
	float leftRightSpeed = 5f;

	//モーション速度
	float Speed = 1.5f;
	float DSpeed = 10;

	//float nextTime;
	//float interval = 0.1f;   // 点滅周期

	Renderer renderComponent1;
	Renderer renderComponent2;
	Renderer renderComponent3;

	bool flag = true;

	//コントローラーのボタン取得
	float L_axisH = 0.0f;
	float L_axisV = 0.0f;
	float R_axisH = 0.0f;
	float R_axisV = 0.0f;
	float D_axisH = 0.0f;
	float D_axisV = 0.0f;
	float T_axis  = 0.0f;

	//当たり判定
	[SerializeField] private CapsuleCollider CC;

	//Rigidbody(重力)
	[SerializeField] private Rigidbody RB;

	//時間の同期
	public static bool two = false;
    public static float twoscond = 0.0f;

	bool Secchi, Kasoku, Gensoku, WL, WR;

    void Start()
	{
		//nextTime = Time.time;

		renderComponent1 = transform.Find("Body").gameObject.GetComponent<Renderer>();
		renderComponent2 = transform.Find("Face").gameObject.GetComponent<Renderer>();
		renderComponent3 = transform.Find("Hair").gameObject.GetComponent<Renderer>();

		transform.Translate(0,0,0);
		CC.radius = 0.26f;
		CC.height = 1.6f;
		CC.center = new Vector3(0, 0.78f, 0);
		CC.direction = 1;
    }
	
	void Update()
	{
		//Lスティック読み込み
		L_axisH = Input.GetAxisRaw("L_Stick_H");
		L_axisV = Input.GetAxisRaw("L_Stick_V");
		R_axisH = Input.GetAxisRaw("R_Stick_H");
		R_axisV = Input.GetAxisRaw("R_Stick_V");
		D_axisH = Input.GetAxisRaw("D_Pad_H");
		D_axisV = Input.GetAxisRaw("D_Pad_V"); 
		T_axis  = Input.GetAxisRaw("L_R_Trigger");

		//ダッシュ中
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
		{
			if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || L_axisH < 0.0f) && !WL)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
			}

			if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || L_axisH > 0.0f) && !WR)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
			}

			CC.center = new Vector3(0, 0.78f, 0);
			CC.direction = 1;
		}

		//ジャンプ中
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Vaut"))
		{
			RB.AddForce(transform.forward * DSpeed * 10, ForceMode.Force);
			RB.AddForce(transform.up * DSpeed * 2, ForceMode.Force);
		}

		//スライディング中
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
		{
			if (Kasoku) 
            {
				RB.AddForce(transform.forward * DSpeed * 30, ForceMode.Force);
			}
			else if (Gensoku)
            {
				RB.AddForce(transform.forward * DSpeed * 30, ForceMode.Force);
			}
            else
			{
				RB.AddForce(transform.forward * DSpeed * 10, ForceMode.Force);
			}
			CC.center = new Vector3(0, CC.radius, 0);
			CC.direction = 2;
		}


		
		//座標取得　場外に行かないように
		Vector3 CharaPosi = this.transform.position;
        if (CharaPosi.y < 0)
        {
			this.transform.position = new Vector3(CharaPosi.x, 0, CharaPosi.z);
		}/*
		if (CharaPosi.x < -2.2)
		{
			this.transform.position = new Vector3(-2.2f, CharaPosi.y, CharaPosi.z);
		}
		if (CharaPosi.x > 2.2)
		{
			this.transform.position = new Vector3(2.2f, CharaPosi.y, CharaPosi.z);
		}*/

		//地面に触れていない間
        if (!Secchi)
        {

		}

		/////////////////////////////////////////
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetFloat("speed", Speed++);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			anim.SetFloat("speed", Speed = 1.5f);
		}
		if (Input.GetKey(KeyCode.E) || R_axisV < 0.0f)
		{
			anim.SetFloat("speed", Speed--);
		}
		//////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.X))
		{
			transform.Rotate(new Vector3(0, 90, 0));
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			transform.Rotate(new Vector3(0, -90, 0));
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			transform.Rotate(new Vector3(0, 180, 0));
		}
		///////////////////////////////////////////
		if (Input.GetKey(KeyCode.Backspace))
		{
			anim.SetFloat("speed", Speed = 0);
		}
		//////////////////////////////////////////
		if (Input.GetKeyDown(KeyCode.R))
		{
			this.transform.position = new Vector3(0, 0, CharaPosi.z);
		}
		/////////////////////////////////////////
		if (L_axisH > 0.0f)
        {
			Debug.Log("L_右");
		}
		if (L_axisH < 0.0f)
		{
			Debug.Log("L_左");
		}
		if (L_axisV > 0.0f)
		{
			Debug.Log("L_上");
		}
		if (L_axisV < 0.0f)
		{
			Debug.Log("L_下");
		}

		if (R_axisH > 0.0f)
		{
			Debug.Log("R_右");
		}
		if (R_axisH < 0.0f)
		{
			Debug.Log("R_左");
		}
		if (R_axisV > 0.0f)
		{
			Debug.Log("R_上");
		}
		if (R_axisV < 0.0f)
		{
			Debug.Log("R_下");
		}

		if (D_axisH > 0.0f)
		{
			Debug.Log("D_右");
		}
		if (D_axisH < 0.0f)
		{
			Debug.Log("D_左");
		}
		if (D_axisV > 0.0f)
		{
			Debug.Log("D_上");
		}
		if (D_axisV < 0.0f)
		{
			Debug.Log("D_下");
		}

		if (T_axis > 0.0f)
		{
			Debug.Log("T_Right");
		}
		if (T_axis < 0.0f)
		{
			Debug.Log("T_Left");
		}
        //////////////////////////////////////////////
        ///
        if (L_axisV < 0.0f && R_axisV > 0.0f && T_axis < 0.0f && D_axisH > 0.0f && Input.GetKeyDown(KeyCode.JoystickButton2) && Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			Sound_SE.Omake();
		}
		///
	}


	//触れた時
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "wall")
		{
			Destroy(other.gameObject);
			StartCoroutine(Blink());
			Sound_SE.Hidan();

			Speed = 0.1f;
		}

		if (other.gameObject.tag == "acceleration")
		{
			Kasoku = true;
		}
		if (other.gameObject.tag == "deceleration")
		{
			Gensoku = true;
		}

		//QTEエリア
		if (other.gameObject.tag == "QTE")
		{
			two = true;
			twoscond = GameManager.countdownSeconds;
			SceneManager.LoadScene("QTE 1", LoadSceneMode.Single);
		}
	}

	//触れている間
	void OnTriggerStay(Collider other)
	{
		//加速版
		if (other.gameObject.tag == "acceleration")
		{
			anim.SetFloat("speed", Speed = 3);
			DSpeed = 15;
		}

		//減速版
		if (other.gameObject.tag == "deceleration")
		{
			anim.SetFloat("speed", Speed = 0.5f);
			DSpeed = -5;
		}
	}

	//離れた時
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "acceleration")
		{
			Kasoku = false;
		}
		if (other.gameObject.tag == "deceleration")
		{
			Gensoku = false;
		}
	}




	//触れたとき
	void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "grand")
        {
			Secchi = true;
		}
		if (other.gameObject.name == "wallObjectR")
		{
			WR = true;
		}
		if (other.gameObject.name == "wallObjectL")
		{
			WL = true;
		}
	}


	//触れている間
    void OnCollisionStay(Collision other)
    {
		//地面
		if (other.gameObject.tag == "grand")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))
			{
				anim.Play("Vaut");
				//瞬間的に力を加える
				RB.AddForce(transform.forward * DSpeed, ForceMode.Impulse);
				RB.AddForce(transform.up * DSpeed, ForceMode.Impulse);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.JoystickButton0))
			{
				anim.Play("Slide");
			}

			if (Speed < 1.5 - 0.05)
			{
				anim.SetFloat("speed", Speed += 0.05f);
			}
			if (Speed > 1.5 + 0.05)
			{
				anim.SetFloat("speed", Speed -= 0.05f);
			}

            if (!Kasoku && !Gensoku)
            {
				DSpeed = 10;
            }
		}
	}


	//離れたとき
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "grand")
        {
			Secchi = false;
		}
		if (other.gameObject.name == "wallObjectR")
		{
			WR = false;
		}
		if (other.gameObject.name == "wallObjectL")
		{
			WL = false;
		}
	}



	IEnumerator Blink()
	{
		if (flag)
		{
			for (int i = 0; i < 5; i++)
			{
				flag = false;
				renderComponent1.enabled = !renderComponent1.enabled;
				renderComponent2.enabled = !renderComponent2.enabled;
				renderComponent3.enabled = !renderComponent3.enabled;
				yield return new WaitForSeconds(0.1f);
				renderComponent1.enabled = !renderComponent1.enabled;
				renderComponent2.enabled = !renderComponent2.enabled;
				renderComponent3.enabled = !renderComponent3.enabled;
				yield return new WaitForSeconds(0.1f);
			}
			flag = true;
		}
	}
}
