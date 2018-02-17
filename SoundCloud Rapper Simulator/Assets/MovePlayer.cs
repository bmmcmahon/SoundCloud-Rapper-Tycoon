using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	Transform transform;
	Rigidbody2D rb;
	Animator animator;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow) ||
			Input.GetKey (KeyCode.DownArrow) ||
			Input.GetKey (KeyCode.LeftArrow) ||
			Input.GetKey (KeyCode.RightArrow)) {

			Vector3 movement = Vector3.zero;

			if (Input.GetKey (KeyCode.UpArrow)) {
				movement += (Vector3.up*1.5f*Time.deltaTime);
				animator.SetInteger ("State", 1);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				movement += (Vector3.down * 1.5f * Time.deltaTime);
				animator.SetInteger ("State", 0);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				movement += (Vector3.left*4f*Time.deltaTime);
				animator.SetInteger ("State", 2);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				movement += (Vector3.right*4f*Time.deltaTime);
				animator.SetInteger ("State", 3);
			}

			if (movement != Vector3.zero) {
				rb.MovePosition(transform.position + movement);
			}
				
//			if (Input.GetKey (KeyCode.RightArrow)) {
//				if (!(_animator.GetInteger ("State") == 0)) {
//					_animator.SetInteger ("State", 0);
//					_state = 0;
//				}
//				_rb.MovePosition (_transform.position + Vector3.right * 6 *  Time.deltaTime);
//			}
//
//			if (Input.GetKey (KeyCode.LeftArrow)) {
//				if (!(_animator.GetInteger ("State") == 4)) {
//					_animator.SetInteger ("State", 4);
//					_state = 4;
//				}
//				_rb.MovePosition (_transform.position + Vector3.left * 6 *  Time.deltaTime);
//			}
//
//			if (Input.GetKey (KeyCode.DownArrow)) {
//				if (!(_animator.GetInteger ("State") == 6)) {
//					_animator.SetInteger ("State", 6);
//					_state = 6;
//				}
//				_rb.MovePosition (_transform.position + Vector3.down * 6 *  Time.deltaTime);
//			}
//		} else {
//			if (!(_animator.GetInteger ("Attack") == 1)) {
//				_animator.SetInteger ("State", _state + 1);
//
//			}
//
//
		}
		
	}
}
