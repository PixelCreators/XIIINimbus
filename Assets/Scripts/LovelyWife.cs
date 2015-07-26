using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LovelyWife : MonoBehaviour
{   
    public int chosenEvent;                 //numer wybranego eventu
    public int shoeOrEvent;                 //but badz event
    public Text eventMessageToDisplay;      //komunikat jaki 
    public int BColor;                      //kolor buta
    public int BType;                       //wzor buta
    public bool XColor;                     //czy nie wybrano
    public bool XType;                      //czy nie wybrano
    public int points;                      //zmienna do decyzyjnosci
    public float startTimer;                //czas co jaki losuje sie event (podstawowy lub specjalny)
    public Controller gameControl;          //obiekt kontrolera
    public Animator anima;                  //referencja do animacji
    public int IDZdarzenia;                 //numer ID animacji

    GameObject myPanel;

    public Sprite event1_lackOfMoney;
    public Sprite event2_grumpyCat;
    public Sprite event3_NedStark;
    public Sprite event4_pfudor;
    public Sprite event5_noLife;

    public bool superGuy;

	void Start () 
    {
        GameObject findController = GameObject.FindWithTag("GameController");
        if(findController != null)
        {
            gameControl = findController.GetComponent<Controller>();
        }
        XColor = true;
        XType = true;

        myPanel = GameObject.FindWithTag("MessagePanel");
        myPanel.SetActive(false);

        Debug.Log("WIFE :: Start korutyny");
        StartCoroutine(ChooseBetweenShoeAndEvent());
        StartCoroutine(pressKey());
        anima = GetComponent<Animator>();

        superGuy = true;
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
            //Animator anim = new Animator();
            //if(anim.GetCurrentAnimatorStateInfo(0).IsName("WifeStanding"));
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
        IDZdarzenia = 10 * BType + BColor;
        anima.SetInteger("IDEvent", IDZdarzenia);
    }

    //function choosing an event
    void RadomlyChooseEvent()
    {
        chosenEvent = Random.Range(1, 6);
           
        switch (chosenEvent)
        {
        case 1:
            Debug.Log("Event number 1 was chosen");
            startEvent1_tooLittleMoney();
            break;
        case 2:
            Debug.Log("Event number 2 was chosen");
            startEvent2_GrumpyCat();
            break;
        case 3:
            Debug.Log("Event number 3 was chosen");
            startEvent3_winterIsComing();
            break;
        case 4:
            Debug.Log("Event number 4 was chosen");
            startEvent4_pfudor();
            break;
        case 5:
            Debug.Log("Event number 5 was chosen");
            startEvent5_noLife();
            break;
        default:
            Debug.Log("No event was chosen");
            break;
        }
    }

    //==========================================
    //EVENTS:

    //OK button

    public void pressOKButton()
    {
        myPanel.SetActive(false);
        Time.timeScale = 1;
    }

    //too little money
    void startEvent1_tooLittleMoney()
    {
        myPanel.SetActive(true);

        if(gameControl.levelDecision >= 300)
        {
            //myPanel.SetActive(true);
            Time.timeScale = 0;

            GameObject findTextMessage = GameObject.FindWithTag("TextMessage");
            if (findTextMessage != null)
            {
                Debug.Log("LOAD :: Zaladowane Text Message Object");
                eventMessageToDisplay = findTextMessage.GetComponent<Text>();
                eventMessageToDisplay.text = "Sorry! Suddenly it turned out that you have too little money! :(\n You can't afford these shoes. Choose an other pair.\n +50 to frustration level,\n decision = 200";
                gameControl.levelDecision = 200;
                gameControl.levelFrustration += 50;

                GameObject findIllustration = GameObject.FindWithTag("EventIllustration");
                Debug.Log(findIllustration.name);
                if (findIllustration != null)
                {
                    findIllustration.GetComponent<Image>().sprite = event1_lackOfMoney;
                }
            }
            Time.timeScale = 0;
        }
    }

    //Grumpy Cat
    void startEvent2_GrumpyCat()
    {
        myPanel.SetActive(true);
        
        GameObject findTextMessage = GameObject.FindWithTag("TextMessage");
        if (findTextMessage != null)
        {
            Debug.Log("LOAD :: Zaladowane Text Message Object");
            eventMessageToDisplay = findTextMessage.GetComponent<Text>();
            eventMessageToDisplay.text = "Oh no!\n Grumpy Cat visited the shop and decided to freeze you with its eyesight.\n +20 to frustration level";
            gameControl.levelFrustration += 20;

            GameObject findIllustration = GameObject.FindWithTag("EventIllustration");
            Debug.Log(findIllustration.name);
            if (findIllustration != null)
            {
                findIllustration.GetComponent<Image>().sprite = event2_grumpyCat;
            }
        }
        Time.timeScale = 0;
    }

    //winter is coming
    void startEvent3_winterIsComing()
    {
        myPanel.SetActive(true);

        GameObject findTextMessage = GameObject.FindWithTag("TextMessage");
        if (findTextMessage != null)
        {
            Debug.Log("LOAD :: Zaladowane Text Message Object");
            eventMessageToDisplay = findTextMessage.GetComponent<Text>();
            eventMessageToDisplay.text = "Winter is coming!\n Snow has just started to fall heavily. Because of the blizzard you're not able to leave the shop.\n +20 to frustration level.";
            gameControl.levelFrustration += 20;

            GameObject findIllustration = GameObject.FindWithTag("EventIllustration");
            Debug.Log(findIllustration.name);
            if (findIllustration != null)
            {
                findIllustration.GetComponent<Image>().sprite = event3_NedStark;
            }
        }
        Time.timeScale = 0;
    }

    //pfudor
    void startEvent4_pfudor()
    {
        if (gameControl.levelFrustration >= 800)
        {
            myPanel.SetActive(true);

            GameObject findTextMessage = GameObject.FindWithTag("TextMessage");
            if (findTextMessage != null)
            {
                Debug.Log("LOAD :: Zaladowane Text Message Object");
                eventMessageToDisplay = findTextMessage.GetComponent<Text>();
                eventMessageToDisplay.text = "How sweeet!!!\n Pink fluffy unicorn is dancing on rainbow! :3\n You become quite relaxed.\n -400 to frustration level";
                gameControl.levelFrustration -= 400;

                GameObject findIllustration = GameObject.FindWithTag("EventIllustration");
                Debug.Log(findIllustration.name);
                if (findIllustration != null)
                {
                    findIllustration.GetComponent<Image>().sprite = event4_pfudor;
                }
            }
            Time.timeScale = 0;
        }
    }

    //no life
    void startEvent5_noLife()
    {
        if (gameControl.levelFrustration >= 700 && superGuy)
        {
            myPanel.SetActive(true);
            superGuy = false;

            GameObject findTextMessage = GameObject.FindWithTag("TextMessage");
            if (findTextMessage != null)
            {
                Debug.Log("LOAD :: Zaladowane Text Message Object");
                eventMessageToDisplay = findTextMessage.GetComponent<Text>();
                eventMessageToDisplay.text = "A specific guy entered to the shop and you realized\n that it is awful to live with a woman, but without her even worse.\n -200 to frustration level";
                gameControl.levelFrustration -= 300;

                GameObject findIllustration = GameObject.FindWithTag("EventIllustration");
                Debug.Log(findIllustration.name);
                if (findIllustration != null)
                {
                    findIllustration.GetComponent<Image>().sprite = event5_noLife;
                }
            }
            Time.timeScale = 0;
        }
    }
}
