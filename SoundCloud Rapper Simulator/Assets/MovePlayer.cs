using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	Transform transform;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow) ||
			Input.GetKey (KeyCode.DownArrow) ||
			Input.GetKey (KeyCode.LeftArrow) ||
			Input.GetKey (KeyCode.RightArrow)) {

			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.position = transform.position + (Vector3.up*.1f);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.position = transform.position + (Vector3.down*.1f);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.position = transform.position + (Vector3.left*.1f);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.position = transform.position + (Vector3.right*.1f);
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
