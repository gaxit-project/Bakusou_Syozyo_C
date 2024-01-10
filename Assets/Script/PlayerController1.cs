using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {

	public float tmpValue = 1.0f;
	public Animator anim;
	
	void Update () {
		anim.SetBool("jump", Input.GetKey (KeyCode.UpArrow));
	}
}
