using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PatientHusband : MonoBehaviour
{	
	// Update is called once per frame

    public Controller myController; //obiekt kontrolera

    public bool smokingUsed = false;
    public bool drinkingUsed = false;
    public bool meditationUsed = false;
    public bool shoutingUsed = false;
    public bool manipulationUsed = false;
    public bool quoteUsed = false;
    public bool justDoItUsed = false;
    public GameObject butt1, butt2, butt3, butt4, butt5, butt6, butt7;
    public Animator anima;
    public int IDZdarzenia;

    void Start()
    {
        GameObject findController = GameObject.FindWithTag("GameController");
        if (findController != null)
        {
            myController = findController.GetComponent<Controller>();
        }
        butt1 = GameObject.Find("Button_7_smoke");
        butt2 = GameObject.Find("Button_9_drinkVodka");
        butt3 = GameObject.Find("Button_8_meditate");
        butt4 = GameObject.Find("Button_10_shout");
        butt5 = GameObject.Find("Button_12_manipulate");
        butt6 = GameObject.Find("Button_11_quoteYoda");
        butt7 = GameObject.Find("Button_13_justDoIt");
        StartCoroutine(pressKey());
        anima = GetComponent<Animator>();
    }

    public int frToSubstr_smoking = 50;
    public int frToSubstr_drinking = 100;
    public int frToSubstr_meditation = 100;
    public int frToSubstr_shouting = 150;
    public int frToSubstr_manipulation = 200;
    public int frToSubstr_quote = 150;
    public int frToSubstr_justDoIt = 200;

    //korutyna dla klawiatury
    IEnumerator pressKey()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKeyDown(KeyCode.Alpha1))
                Smoke();
            if (Input.GetKeyDown(KeyCode.Alpha2))
                DrinkVodka();
            if (Input.GetKeyDown(KeyCode.Alpha3))
                Meditate();
            if (Input.GetKeyDown(KeyCode.Alpha4))
                Shout();

            if (Input.GetKeyDown(KeyCode.Alpha5))
                Manipulate();
            if (Input.GetKeyDown(KeyCode.Alpha6))
                QuoteYoda();
            if (Input.GetKeyDown(KeyCode.Alpha7))
                JustDoIt();
        }
    }

    //ACTIONS:
    public void Smoke()
    {
        if (smokingUsed == false)
        {
            anima.SetInteger("IDHusbanda", 1);
            if (myController.levelFrustration > frToSubstr_smoking)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_smoking;
            else
                myController.levelFrustration = 0;
            smokingUsed = true;
            
        }
        else
            return;
    }

    public void DrinkVodka()
    {
        if (drinkingUsed == false)
        {
            anima.SetInteger("IDHusbanda", 2);
            if (myController.levelFrustration > frToSubstr_drinking)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_drinking;
            else
                myController.levelFrustration = 0;
            drinkingUsed = true;

        }
        else
            return;
    }

    public void Meditate()
    {
        if (meditationUsed == false)
        {
            anima.SetInteger("IDHusbanda", 3);
            if (myController.levelFrustration > frToSubstr_meditation)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_meditation;
            else
                myController.levelFrustration = 0;
            meditationUsed = true;
        }
        else
            return;
    }

    public void Shout()
    {
        if (shoutingUsed == false)
        {
            anima.SetInteger("IDHusbanda", 4);
            if (myController.levelFrustration > frToSubstr_shouting)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_shouting;
            else
                myController.levelFrustration = 0;
            shoutingUsed = true;
        }
        else
            return;
    }

    public void Manipulate()
    {
        if (manipulationUsed == false)
        {
            if (myController.levelFrustration > frToSubstr_manipulation)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_manipulation;
            else
                myController.levelFrustration = 0;
            manipulationUsed = true;
        }
        else
            return;
    }

    public void QuoteYoda() //"Buy or do not buy. There is no try."
    {
        if (quoteUsed == false)
        {
            if (myController.levelFrustration > frToSubstr_quote)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_quote;
            else
                myController.levelFrustration = 0;

            if (myController.levelDecision < 400)
                myController.levelDecision = myController.levelDecision + 100;
            else
                myController.levelDecision = 500;

            quoteUsed = true;
        }
        else
            return;
    }

    public void JustDoIt()
    {
        if (justDoItUsed == false)
        {
            anima.SetInteger("IDHusbanda", 7);
            if (myController.levelFrustration > frToSubstr_justDoIt)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_justDoIt;
            else
                myController.levelFrustration = 0;

            if (myController.levelDecision < 300)
                myController.levelDecision = myController.levelDecision + 200;
            else
                myController.levelDecision = 500;

            justDoItUsed = true;
        }
        else
            return;
    }
}
