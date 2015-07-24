using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Frustration : MonoBehaviour
{

	// Use this for initialization

    public float frustrationLevel = 0;
    Text frustrationLevelText;


    void Awake
    {
        frustrationLevelText = GetComponent<Text>();
    }

	void Start ()
    {
	    //frustrationLevelText.text = "Level of frustration: " + frustrationLevel;
        frustrationLevelText.text = "Hello World!" + frustrationLevel;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //frustrationLevel = frustrationLevel + Time.deltaTime * 10;
        //frustrationLevelText.text = "Level of frustration: " + frustrationLevel;

        //frustrationLevelText.text = "Hello World!!!!!!!!!!!!!!!!!!!!!!!!!!";

        frustrationLevel = frustrationLevel + 1;
        frustrationLevelText.text = "Hello World!" + frustrationLevel;
	}
}
