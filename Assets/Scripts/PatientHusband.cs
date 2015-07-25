using UnityEngine;
using System.Collections;

public class PatientHusband : MonoBehaviour
{	
	// Update is called once per frame

    public Controller myController; //obiekt kontrolera
    bool meditationUsed = false;
    bool smokingUsed = false;
    bool shoutingUsed = false;
    bool drinkingUsed = false;
    bool quoteUsed = false;
    bool manipulationUsed = false;
    bool justDoItUsed = false;

    void Start()
    {
        GameObject findController = GameObject.FindWithTag("GameController");
        if (findController != null)
        {
            myController = findController.GetComponent<Controller>();
        }
    }


    //ACTIONS:
    public void Meditate()
    {
        if (meditationUsed == false)
        {
            if (myController.levelFrustration > 50)
                myController.levelFrustration = myController.levelFrustration - 50;
            else
                myController.levelFrustration = 0;
            meditationUsed = true;
        }
        else
            return;
    }

    public void Smoke()
    {
        if (smokingUsed == false)
        {
            if (myController.levelFrustration > 50)
                myController.levelFrustration = myController.levelFrustration - 50;
            else
                myController.levelFrustration = 0;
            smokingUsed = true;
        }
        else
            return;
    }

    public void Shout()
    {
        if (shoutingUsed == false)
        {
            if (myController.levelFrustration > 100)
                myController.levelFrustration = myController.levelFrustration - 100;
            else
                myController.levelFrustration = 0;
            shoutingUsed = true;
        }
        else
            return;
    }

    public void DrinkVodka()
    {
        if (drinkingUsed == false)
        {
            if (myController.levelFrustration > 100)
                myController.levelFrustration = myController.levelFrustration - 100;
            else
                myController.levelFrustration = 0;
            drinkingUsed = true;
        }
        else
            return;
    }

    public void QuoteYoda() //"Buy or do not buy. There is no try."
    {
        if (quoteUsed == false)
        {
            if (myController.levelFrustration > 150)
                myController.levelFrustration = myController.levelFrustration - 150;
            else
                myController.levelFrustration = 0;
            quoteUsed = true;
        }
        else
            return;
    }

    public void Manipulate()
    {
        if (manipulationUsed == false)
        {
            if (myController.levelFrustration > 150)
                myController.levelFrustration = myController.levelFrustration - 150;
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
            if (myController.levelFrustration > 200)
                myController.levelFrustration = myController.levelFrustration - 200;
            else
                myController.levelFrustration = 0;
            justDoItUsed = true;
        }
        else
            return;
    }

	void Update ()
    {
	
	}
}
