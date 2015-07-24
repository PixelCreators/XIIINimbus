using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public Text frustrationLevel;   //objekt wyswietlajacy poziom frustracji
    public Text decisionLevel;      //obiekt wyswietlajacy poziom zdecydowania
    public int levelFrustration;    //zmienna z wynikiem frustracji
    public int levelDecision;       //zmienna z wynikiem zdecydowania
    public int incFrustration;      //zmienna o ile zwieksza sie z czasem frustracja
    public float incFrustTime;      //zmienna czasu

	void Start () {
        //wczytywanie obiektów tekstowych
        GameObject frustrationFind = GameObject.FindWithTag("Frustration");
        if (frustrationFind != null)
        {
            Debug.Log("LOAD :: Zaladowane Frustration Object");
            frustrationLevel = frustrationFind.GetComponent<Text>();
            frustrationLevel.text = "Frustration: " + levelFrustration;
        }
        GameObject decisionFind = GameObject.FindWithTag("Decision");
        if (decisionFind != null)
        {
            Debug.Log("LOAD :: Zaladowane Decision Object");
            decisionLevel = decisionFind.GetComponent<Text>();
            decisionLevel.text = "Decision: " + levelDecision;
        }
        levelFrustration = 0;   //frustracja na 0
        levelDecision = 0;      //zdecydowanie na 0

        StartCoroutine(FrustrationINC());
	}
	
	void Update () {
	
	}

    IEnumerator FrustrationINC()
    {
        while(true)
        {
            yield return new WaitForSeconds(incFrustTime);
            levelFrustration = incFrustration + levelFrustration;
            frustrationLevel.text = "Frustration: " + levelFrustration;
            //Debug.Log("CORUT :: Niby zwieksza frustracje");
        }
    }
}
