using UnityEngine;
using System.Collections;

public class LookToWalkVR : MonoBehaviour 
{
	private CharacterController charControl;
	private Clicker click = new Clicker();
	public bool walking=false;
	public float speed = 0.7F;
	void Start ()
	{
		charControl=GetComponent<CharacterController>();
	}
	void Update ()
	{
		if (click.clicked())
		{
			walking = !walking;
		}
		if (walking)
		{
			charControl.SimpleMove (Camera.main.transform.forward*speed);
		}
	}
}
