using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour {

	public static PlayerManager instance;

	public const int MAX_SPEED = 10;
	private bool isCounting = false;
	private Canvas canvas;
	private Text speed;
	private Text scoreUI;
	private ControlSet currentControls;
	private Rigidbody rb;
	private float boostCD = 0;
	private bool isBoosting = false;
	public int score;

	private void Awake() {
		if(instance == null)
			instance = this;
		else
			Debug.LogError("MORE THAT ONE PLAYER IN SCENE");

		currentControls = ControlSet.GetControls();
		currentControls.Start();
		canvas = GameObject.FindWithTag("MainCanvas").GetComponent<Canvas>();
		speed = canvas.transform.Find("Speed").GetComponent<Text>();
		scoreUI = canvas.transform.Find("Score").GetComponent<Text>();
		rb = GetComponent<Rigidbody>();
		currentControls.moveInput += Move;
		currentControls.jumpInput += Boost;
	}

	private void LateUpdate () {
		currentControls.CheckInput();
		speed.text = "Speed: " + rb.velocity.z.ToString();
		scoreUI.text = "Score: " + score.ToString();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Obstacle") {
			SceneManager.LoadScene(0);
		}
	}

	public void Move(float axis) {
		rb.AddForce(new Vector3(axis, 0, 0));
		if(boostCD > 0 && !isCounting)
			StartCoroutine(ReduceBoostCount());
		if(rb.velocity.z < MAX_SPEED + score / 4 && !isBoosting) {
			rb.AddForce(new Vector3(0,0,1 + score/4) * Time.deltaTime, ForceMode.Impulse);
		}
		if(rb.velocity.z > MAX_SPEED + score/4 && !isBoosting) {
				rb.velocity = rb.velocity * 0.9f;
			}

		if(rb.transform.position.x < -1.3f || rb.transform.position.x > 1.3f) {
			rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
		}
		rb.transform.position = new Vector3(Mathf.Clamp(rb.transform.position.x, -1.3f, 1.3f), rb.transform.position.y, rb.transform.position.z);
	}

	public void Boost() {
		if(boostCD <= 0) {
			StartCoroutine(BoostEnum());
		}
	}

	private IEnumerator ReduceBoostCount() {
		isCounting = true;
		yield return new WaitForSeconds(1f);
		boostCD--;
		isCounting = false;
	}

	private IEnumerator BoostEnum() {
		Debug.Log("Start boost");
		boostCD = 10;
		isBoosting = true;
		if(rb.velocity.z < MAX_SPEED * 6) {
			rb.AddForce(Vector3.forward * (MAX_SPEED * 6));
		}
		if(rb.velocity.z > MAX_SPEED * 6) {
			rb.velocity = rb.velocity * 0.9f;
		}
		yield return new WaitForSeconds(3f);
		isBoosting = false;
		Debug.Log("End boost");
	}
}

