using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	// Use this for initialization

    public int frustrationLevel = 0;
    public Text frustrationLevelText;

    void Start () {
        frustrationLevelText.text = "Level of frustration: " + frustrationLevel;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
