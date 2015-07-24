using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public Text frustrationLevel;
    public int levelFrustration;

	void Start () {
        GameObject textFrustrationFinding = GameObject.FindWithTag("Frustration");
        if(textFrustrationFinding != null)
        {
            Debug.Log("LOAD :: Zaladowane Frustration Object");
            frustrationLevel = textFrustrationFinding.GetComponent<Text>();
            frustrationLevel.text = "Frustration: " + levelFrustration;
        }
        levelFrustration = 0;
	}
	
	void Update () {
	
	}
}
