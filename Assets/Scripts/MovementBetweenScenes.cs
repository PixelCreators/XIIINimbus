using UnityEngine;
using System.Collections;

public class MovementBetweenScenes : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
        //GameObject findExitButton = GameObject.FindWithTag("ExitButton");
        //if()
	}
}
