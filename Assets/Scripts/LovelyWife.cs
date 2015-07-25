using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LovelyWife : MonoBehaviour {

    public int BColor;              //kolor buta
    public int BType;               //wzor buta
    public bool XColor;             //czy nie wybrano
    public bool XType;              //czy nie wybrano
    public int points;              //zmienna do decyzyjnosci
    public float startEventTime;    //czas co jaki losuje sie event (podstawowy lub specjalny)
    public Controller gameControl;  //obiekt kontrolera

	void Start () 
    {
        GameObject findController = GameObject.FindWithTag("GameController");
        if(findController != null)
        {
            gameControl = findController.GetComponent<Controller>();
        }
        XColor = true;
        XType = true;
        Debug.Log("WIFE :: Start korutyny");
        StartCoroutine(Losuj());
        StartCoroutine(pressKey());
	}
    //korutyna pilnujaca klawiatury w evencie podstawowym
    IEnumerator pressKey()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKeyDown(KeyCode.Q) && XColor)
                actionKey(1, 1);
            if (Input.GetKeyDown(KeyCode.W) && XColor)
                actionKey(1, 2);
            if (Input.GetKeyDown(KeyCode.E) && XColor)
                actionKey(1, 3);
            if (Input.GetKeyDown(KeyCode.R) && XColor)
                actionKey(1, 4);

            if (Input.GetKeyDown(KeyCode.A) && XType)
                actionKey(2, 1);
            if (Input.GetKeyDown(KeyCode.S) && XType)
                actionKey(2, 2);
            if (Input.GetKeyDown(KeyCode.D) && XType)
                actionKey(2, 3);
            if (Input.GetKeyDown(KeyCode.F) && XType)
                actionKey(2, 4);
        }
    }
    //akcje jakie wykonuje przycisk przy eventach podstawowych
    void actionKey(int y, int x)
    {
        if(checkKey(y,x))
        {
            Debug.Log("SUPER");
            gameControl.levelDecision += points;
        }
        else
        {
            Debug.Log("FALSE");
            gameControl.levelDecision -= points;
        }
    }
    //sprawdzenie czy zgadza sie liczba z wylosowanym randomem
    bool checkKey(int y, int x)
    {
        if(y == 1)
        {
            XColor = false;
            if (BColor == x)
                return true;
            else
                return false;
        }
        else
        {
            XType = false;
            if (BType == x)
                return true;
            else
                return false;
        }
    }
    //korutyna losujaca event
    IEnumerator Losuj()
    {
        while (true)
        {
            yield return new WaitForSeconds(startEventTime);
            BColor = Random.Range(1, 5);
            XColor = true;
            BType = Random.Range(1, 5);
            XType = true;
        }
    }
}
