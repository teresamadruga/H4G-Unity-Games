using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {
	public string [] levelNames;
	public int gameLevelNum;
	public void Start ()
	{
		DontDestroyOnLoad (this.gameObject);
	}
	public void LoadLevel (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
	public void GoNextLevel()
	{
		if( gameLevelNum >= levelNames.Length )
			gameLevelNum = 0;
		LoadLevel( gameLevelNum );
		gameLevelNum++;
	}
	private void LoadLevel( int indexNum )
	{ 
		LoadLevel( levelNames[indexNum] );
	}
	public void ResetGame()
	{
		gameLevelNum = 0;
	}
}
