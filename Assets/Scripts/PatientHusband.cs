using UnityEngine;
using System.Collections;

public class PatientHusband : MonoBehaviour
{	
	// Update is called once per frame

    public Controller myController; //obiekt kontrolera

    public bool smokingUsed = false;
    public bool meditationUsed = false;
    public bool drinkingUsed = false;
    public bool shoutingUsed = false;
    public bool quoteUsed = false;
    public bool manipulationUsed = false;
    public bool justDoItUsed = false;

    void Start()
    {
        GameObject findController = GameObject.FindWithTag("GameController");
        if (findController != null)
        {
            myController = findController.GetComponent<Controller>();
        }
    }

    public int frToSubstr_smoking = 50;
    public int frToSubstr_meditation = 100;
    public int frToSubstr_drinking = 100;
    public int frToSubstr_shouting = 150;
    public int frToSubstr_quote = 150;
    public int frToSubstr_manipulation = 200;
    public int frToSubstr_justDoIt = 200;

    //ACTIONS:
    public void Smoke()
    {
        if (smokingUsed == false)
        {
            if (myController.levelFrustration > frToSubstr_smoking)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_smoking;
            else
                myController.levelFrustration = 0;
            smokingUsed = true;
        }
        else
            return;
    }

    public void Meditate()
    {
        if (meditationUsed == false)
        {
            if (myController.levelFrustration > frToSubstr_meditation)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_meditation;
            else
                myController.levelFrustration = 0;
            meditationUsed = true;
        }
        else
            return;
    }

    public void DrinkVodka()
    {
        if (drinkingUsed == false)
        {
            if (myController.levelFrustration > frToSubstr_drinking)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_drinking;
            else
                myController.levelFrustration = 0;
            drinkingUsed = true;
        }
        else
            return;
    }

    public void Shout()
    {
        if (shoutingUsed == false)
        {
            if (myController.levelFrustration > frToSubstr_shouting)
                myController.levelFrustration = myController.levelFrustration - frToSubstr_shouting;
            else
                myController.levelFrustration = 0;
            shoutingUsed = true;
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

    public void JustDoIt()
    {
        if (justDoItUsed == false)
        {
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

	void Update ()
    {
	
	}
}
