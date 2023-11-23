using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//シーン切り替えに使用するライブラリ
using UnityEngine.SceneManagement;


public class PlayerController2 : MonoBehaviour
{
	float tmpValue = 50.0f;
	public Animator anim;
	float leftRightSpeed = 5f;
	public AudioClip sound1;

	//モーション速度
	float Speed = 1.5f;
	float DSpeed = 10;

	[SerializeField] private Transform _grandChild;

	private float nextTime;
	float interval = 0.1f;   // 点滅周期

	Renderer renderComponent1;
	Renderer renderComponent2;
	Renderer renderComponent3;

	private bool flag = true;

	float axisH = 0.0f;
	public AudioSource audioSource2;

	//当たり判定
	[SerializeField] private CapsuleCollider CC;

	//Rigidbody(重力)
	[SerializeField] private Rigidbody RB;

	//時間の同期
	public static bool two = false;
    public static float twoscond = 0.0f;

	bool Setchi, Kasoku, Gensoku;

    void Start()
	{
		nextTime = Time.time;

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
		axisH = Input.GetAxisRaw("Horizontal");

		//ダッシュ中
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || axisH < 0.0f)
			{
				transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
			}

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || axisH > 0.0f)
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
			RB.AddForce(transform.forward * DSpeed * 20, ForceMode.Force);
			CC.center = new Vector3(0, CC.radius, 0);
			CC.direction = 2;
		}



		//座標取得　場外に行かないように
		Vector3 CharaPosi = this.transform.position;
        if (CharaPosi.y < 0)
        {
			this.transform.position = new Vector3(CharaPosi.x, 0, CharaPosi.z);
		}
		if (CharaPosi.x < -2.2)
		{
			this.transform.position = new Vector3(-2.2f, CharaPosi.y, CharaPosi.z);
		}
		if (CharaPosi.x > 2.2)
		{
			this.transform.position = new Vector3(2.2f, CharaPosi.y, CharaPosi.z);
		}

		//地面に触れていない間
        if (!Setchi)
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
		if (Input.GetKey(KeyCode.E))
		{
			anim.SetFloat("speed", Speed = -0.5f);
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
	}


	//触れた時
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "wall")
		{
			Destroy(other.gameObject);
			StartCoroutine(Blink());
			audioSource2.PlayOneShot(sound1);

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
			Setchi = true;
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
			Setchi = false;
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
