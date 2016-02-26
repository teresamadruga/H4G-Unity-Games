using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class XML_Save_System : MonoBehaviour
{
	XmlDocument xPlayer = new XmlDocument();
	XmlDocument xEnemy = new XmlDocument();
	public string pFileName = "";
	public string eFileName = "";
	public GameObject Player;
	public GameObject[] Enemies;

	void Start()
	{
		xPlayer.LoadXml(System.IO.File.ReadAllText(pFileName));
		xEnemy.LoadXml(System.IO.File.ReadAllText(eFileName));
	}

	#region Save/Load Player Data
	void SavePlayer()
	{
		if(Player != null)
		{
			XmlNode root = xPlayer.FirstChild;
			
			foreach(XmlNode node in root.ChildNodes)
			{
				switch(node.Name)
				{
				case "xPos":
					node.InnerText = Player.transform.position.x.ToString();
					break;
				case "yPos":
					node.InnerText = Player.transform.position.y.ToString();
					break;
				case "zPos":
					node.InnerText = Player.transform.position.z.ToString();
					break;
				case "xRot":
					node.InnerText = Player.transform.rotation.x.ToString();
					break;
				case "yRot":
					node.InnerText = Player.transform.rotation.y.ToString();
					break;
				case "zRot":
					node.InnerText = Player.transform.rotation.z.ToString();
					break;
				case "xScale":
					node.InnerText = Player.transform.localScale.x.ToString();
					break;
				case "yScale":
					node.InnerText = Player.transform.localScale.y.ToString();
					break;
				case "zScale":
					node.InnerText = Player.transform.localScale.z.ToString();
					break;
				}
			}
			xPlayer.Save(pFileName);
		}
	}
	
	void LoadPlayer()
	{
		float xPos = 0.00f;
		float yPos = 0.00f;
		float zPos = 0.00f;
		float xRot = 0.00f;
		float yRot = 0.00f;
		float zRot = 0.00f;
		float xScale = 0.00f;
		float yScale = 0.00f;
		float zScale = 0.00f;
		
		if(Player != null)
		{
			XmlNode root = xPlayer.FirstChild;
			foreach(XmlNode node in root.ChildNodes)
			{
				switch(node.Name)
				{
				case "xPos":
					xPos = Convert.ToSingle(node.InnerText);
					break;
				case "yPos":
					yPos = Convert.ToSingle(node.InnerText);
					break;
				case "zPos":
					zPos = Convert.ToSingle(node.InnerText);
					break;
				case "xRot":
					xRot = Convert.ToSingle(node.InnerText);
					break;
				case "yRot":
					yRot = Convert.ToSingle(node.InnerText);
					break;
				case "zRot":
					zRot = Convert.ToSingle(node.InnerText);
					break;
				case "xScale":
					xScale = Convert.ToSingle(node.InnerText);
					break;
				case "yScale":
					yScale = Convert.ToSingle(node.InnerText);
					break;
				case "zScale":
					zScale = Convert.ToSingle(node.InnerText);
					break;
				}
			}
			
			Player.transform.position = new Vector3(xPos, yPos, zPos);
			Player.transform.rotation = new Quaternion(xRot, yRot, zRot, 0.00f);
			Player.transform.localScale = new Vector3(xScale, yScale, zScale);
		}
	}
	#endregion

	#region Save/Load Enemy Data
	void SaveEnemies()
	{
		xEnemy.RemoveAll();

		XmlNode eRoot = xEnemy.CreateNode(XmlNodeType.Element, "eData", "");
		string[] nodes = {"name", "xPos", "yPos", "zPos", "xRot", "yRot", "zRot", "xScale", "yScale", "zScale"};

		for(int e = 0; e < Enemies.Length; e++)
		{
			if(Enemies[e] != null)
			{
				XmlNode eBase = xEnemy.CreateNode(XmlNodeType.Element, "enemy", "");

				for(int n = 0; n < nodes.Length; n++)
				{
					XmlNode newNode = xEnemy.CreateNode(XmlNodeType.Element, nodes[n], "");

					eBase.AppendChild(newNode);
				}

				foreach(XmlNode node in eBase.ChildNodes)
				{
					switch(node.Name)
					{
					case "name":
						node.InnerText = Enemies[e].name;
						break;
					case "xPos":
						node.InnerText = Enemies[e].transform.position.x.ToString();
						break;
					case "yPos":
						node.InnerText = Enemies[e].transform.position.y.ToString();
						break;
					case "zPos":
						node.InnerText = Enemies[e].transform.position.z.ToString();
						break;
					case "xRot":
						node.InnerText = Enemies[e].transform.rotation.x.ToString();
						break;
					case "yRot":
						node.InnerText = Enemies[e].transform.rotation.y.ToString();
						break;
					case "zRot":
						node.InnerText = Enemies[e].transform.rotation.z.ToString();
						break;
					case "xScale":
						node.InnerText = Enemies[e].transform.localScale.x.ToString();
						break;
					case "yScale":
						node.InnerText = Enemies[e].transform.localScale.y.ToString();
						break;
					case "zScale":
						node.InnerText = Enemies[e].transform.localScale.z.ToString();
						break;
					}

					eRoot.AppendChild(eBase);
				}
				
				xEnemy.AppendChild(eRoot);
			}
		}
		
		xEnemy.Save(eFileName);
	}

	
	void LoadEnemies()
	{
		string name = "";
		float xPos = 0.00f;
		float yPos = 0.00f;
		float zPos = 0.00f;
		float xRot = 0.00f;
		float yRot = 0.00f;
		float zRot = 0.00f;
		float xScale = 0.00f;
		float yScale = 0.00f;
		float zScale = 0.00f;
		
		for(int e = 0; e < Enemies.Length; e++)
		{
			if(Enemies[e] != null)
			{
				XmlNode eData = xEnemy.FirstChild;

				XmlNode enemy = eData.ChildNodes[e];

				if(enemy.Name == "enemy")
				{
					foreach(XmlNode eNode in enemy.ChildNodes)
					{
						switch(eNode.Name)
						{
						case "name":
							name = eNode.InnerText;
							break;
						case "xPos":
							xPos = Convert.ToSingle(eNode.InnerText);
							break;
						case "yPos":
							yPos = Convert.ToSingle(eNode.InnerText);
							break;
						case "zPos":
							zPos = Convert.ToSingle(eNode.InnerText);
							break;
						case "xRot":
							xRot = Convert.ToSingle(eNode.InnerText);
							break;
						case "yRot":
							yRot = Convert.ToSingle(eNode.InnerText);
							break;
						case "zRot":
							zRot = Convert.ToSingle(eNode.InnerText);
							break;
						case "xScale":
							xScale = Convert.ToSingle(eNode.InnerText);
							break;
						case "yScale":
							yScale = Convert.ToSingle(eNode.InnerText);
							break;
						case "zScale":
							zScale = Convert.ToSingle(eNode.InnerText);
							break;
						}

						Enemies[e].name = name;
						Enemies[e].transform.localPosition = new Vector3(xPos, yPos, zPos);
						Enemies[e].transform.localRotation = new Quaternion(xRot, yRot, zRot, 0.00f);
						Enemies[e].transform.localScale = new Vector3(xScale, yScale, zScale);
					}
				}
			}
		}
	}
	#endregion
}