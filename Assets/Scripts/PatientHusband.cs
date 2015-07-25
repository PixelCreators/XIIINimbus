using UnityEngine;
using System.Collections;

public class PatientHusband : MonoBehaviour
{	
	// Update is called once per frame

    public Controller myController; //obiekt kontrolera
    public int deltaFrustration = 50;    //roznica, o jaka zmienia sie frustracja w wyniku eventu lub akcji meza

    void Start()
    {
        
    }

    public void Smoke()
    {
        myController.levelFrustration = myController.levelFrustration - deltaFrustration;
    }

	void Update ()
    {
	
	}
}
