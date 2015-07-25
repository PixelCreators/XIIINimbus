using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LovelyWife : MonoBehaviour
{
    public float startTimer; //czas, co jaki ma byc dokonany wybor miedzy butem a eventem
    public int shoeOrEvent;
    
    public int chosenEvent;                 //numer wybranego eventu
    
    public int BColor;                      //kolor buta
    public int BType;                       //wzor buta
    public bool XColor;                     //czy nie wybrano
    public bool XType;                      //czy nie wybrano
    public int points;                      //zmienna do decyzyjnosci
    public float startWifesChoisesTimer;    //czas co jaki losuje sie event (podstawowy lub specjalny)
    public Controller gameControl;          //obiekt kontrolera

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
        StartCoroutine(ChooseBetweenShoeAndEvent());
        StartCoroutine(pressKey());
	}
    //korutyna pilnujaca klawiatury w evencie podstawowym
    IEnumerator pressKey()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKeyDown(KeyCode.A) && XColor)
                actionKey(1, 1);
            if (Input.GetKeyDown(KeyCode.S) && XColor)
                actionKey(1, 2);
            if (Input.GetKeyDown(KeyCode.D) && XColor)
                actionKey(1, 3);
            if (Input.GetKeyDown(KeyCode.F) && XColor)
                actionKey(1, 4);

            if (Input.GetKeyDown(KeyCode.Q) && XType)
                actionKey(2, 1);
            if (Input.GetKeyDown(KeyCode.W) && XType)
                actionKey(2, 2);
            if (Input.GetKeyDown(KeyCode.E) && XType)
                actionKey(2, 3);
        }
    }

    public void pressButton(string buttonType)
    {
            if (buttonType.Equals("ButtonRedColour") && XColor)
                actionKey(1, 1);
            if (buttonType.Equals("ButtonGreenColour") && XColor)
                actionKey(1, 2);
            if (buttonType.Equals("ButtonBlueColour") && XColor)
                actionKey(1, 3);
            if (buttonType.Equals("ButtonYellowColour") && XColor)
                actionKey(1, 4);

            if (buttonType.Equals("ButtonHighHeels") && XColor)
                actionKey(2, 1);
            if (buttonType.Equals("ButtonAdidasShoes") && XColor)
                actionKey(2, 2);
            if (buttonType.Equals("ButtonTrainers") && XColor)
                actionKey(2, 3);
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
    
    //coroutine choosing between a shoe and an event
    IEnumerator ChooseBetweenShoeAndEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(startTimer);
            shoeOrEvent = Random.Range(1, 3);

            switch (shoeOrEvent)
            {
            case 1:
                Losuj();
                break;
            case 2:
                RadomlyChooseEvent();
                break;
            default:
                Debug.Log("Nothing was chosen to happen");
                break;
            }
        }
    }

    //function choosing a shoe
    void Losuj()
    {
        BColor = Random.Range(1, 5);
        XColor = true;
        BType = Random.Range(1, 4);
        XType = true;
    }

    //function choosing an event
    void RadomlyChooseEvent()
    {
        chosenEvent = Random.Range(1, 6);

        switch (chosenEvent)
        {
        case 1:
            Debug.Log("Event number 1 was chosen");
            break;
        case 2:
            Debug.Log("Event number 2 was chosen");
            break;
        case 3:
            Debug.Log("Event number 3 was chosen");
            break;
        case 4:
            Debug.Log("Event number 4 was chosen");
            break;
        case 5:
            Debug.Log("Event number 5 was chosen");
            break;
        default:
            Debug.Log("No event was chosen");
            break;
        }
    }
}
