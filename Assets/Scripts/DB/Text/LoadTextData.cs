using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadTextData : MonoBehaviour 
{
	private Text MyText = null;

	private TextAsset TextData = null;
	void Awake () {
		MyText = GetComponent<Text>();

		TextData = Resources.Load("TextData") as TextAsset;
	}
	void Update () {
		MyText.text = TextData.text;
	}
}
