//-----------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class ObjSerializer : MonoBehaviour
{
	[System.Serializable]
	[XmlRoot("GameData")]
	public class MySaveData
	{
		[System.Serializable]
		public struct DataTransform
		{
			public float X;
			public float Y;
			public float Z;
			public float RotX;
			public float RotY;
			public float RotZ;
			public float ScaleX;
			public float ScaleY;
			public float ScaleZ;
		}

		public DataTransform MyTransform = new DataTransform();
	}

	public MySaveData MyData = new MySaveData();
	private void GetTransform()
	{
		Transform ThisTransform = transform;

		MyData.MyTransform.X = ThisTransform.position.x;
		MyData.MyTransform.Y = ThisTransform.position.y;
		MyData.MyTransform.Z = ThisTransform.position.z;
		MyData.MyTransform.RotX = ThisTransform.localRotation.eulerAngles.x;
		MyData.MyTransform.RotY = ThisTransform.localRotation.eulerAngles.y;
		MyData.MyTransform.RotZ = ThisTransform.localRotation.eulerAngles.z;
		MyData.MyTransform.ScaleX = ThisTransform.localScale.x;
		MyData.MyTransform.ScaleY = ThisTransform.localScale.y;
		MyData.MyTransform.ScaleZ = ThisTransform.localScale.z;
	}
	private void SetTransform()
	{
		Transform ThisTransform = transform;

		ThisTransform.position = new Vector3(MyData.MyTransform.X, MyData.MyTransform.Y, MyData.MyTransform.Z);
		ThisTransform.rotation = Quaternion.Euler(MyData.MyTransform.RotX, MyData.MyTransform.RotY, MyData.MyTransform.RotZ);
		ThisTransform.localScale = new Vector3(MyData.MyTransform.ScaleX, MyData.MyTransform.ScaleY, MyData.MyTransform.ScaleZ);
	}
	public void SaveXML(string FileName = "GameData.xml")
	{
		GetTransform();

		XmlSerializer Serializer = new XmlSerializer(typeof(MySaveData));
		FileStream Stream = new FileStream(FileName, FileMode.Create);
		Serializer.Serialize(Stream, MyData);
		Stream.Close();
	}
	public void LoadXML(string FileName = "GameData.xml")
	{
		if(!File.Exists(FileName)) return;

		XmlSerializer Serializer = new XmlSerializer(typeof(MySaveData));
		FileStream Stream = new FileStream(FileName, FileMode.Open);
		MyData = Serializer.Deserialize(Stream) as MySaveData;
		Stream.Close();

		SetTransform();
	}
	public void SaveBinary(string FileName = "GameData.sav")
	{
		GetTransform();

		BinaryFormatter bf = new BinaryFormatter();
		FileStream Stream = File.Create(FileName);
		bf.Serialize(Stream, MyData);
		Stream.Close();
	}
	public void LoadBinary(string FileName = "GameData.sav")
	{
		if(!File.Exists(FileName)) return;

		BinaryFormatter bf = new BinaryFormatter();
		FileStream Stream = File.Open(FileName, FileMode.Open);
		MyData = bf.Deserialize(Stream) as MySaveData;
		Stream.Close();

		SetTransform();
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SaveXML(Application.persistentDataPath + "/Mydata.xml");
			Debug.Log ("Saved to: " + Application.persistentDataPath + "/Mydata.xml");
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			LoadXML(Application.persistentDataPath + "/Mydata.xml");
			Debug.Log ("Loaded from: " + Application.persistentDataPath + "/Mydata.xml");
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			SaveBinary(Application.persistentDataPath + "/Mydata.sav");
			Debug.Log ("Saved to: " + Application.persistentDataPath + "/Mydata.sav");
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			LoadBinary(Application.persistentDataPath + "/Mydata.sav");
			Debug.Log ("Loaded from: " + Application.persistentDataPath + "/Mydata.sav");
		}
	}
}
