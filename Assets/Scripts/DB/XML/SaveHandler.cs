using UnityEngine;
using System.Collections;

public class SaveHandler : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "SavePoint")
		{
			Camera.main.SendMessage("WriteToFile");
			Destroy(other.gameObject);
		}
	}

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.F1))
		{
			Camera.main.SendMessage("SaveEnemies");
		}
		if(Input.GetKeyUp(KeyCode.F2))
		{
			Camera.main.SendMessage("LoadEnemies");
		}
	}
}