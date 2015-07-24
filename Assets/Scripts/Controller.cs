using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{

    public Text frustrationLevel;   //objekt wyswietlajacy poziom frustracji
    public Text decisionLevel;      //obiekt wyswietlajacy poziom zdecydowania
    public Image frustrationBar;    //przedstawienie graficzne frustracji
    public Image decisionBar;       //przedstawienie graficzne zdecydowania
    public float levelFrustration;  //zmienna z wynikiem frustracji
    public float maxlevelFrustration;//maksymalna wartosc frustracji
    public float levelDecision;     //zmienna z wynikiem zdecydowania
    public float maxlevelDecision;  //maksymalna wartosc zdecydowania
    public float incFrustration;    //zmienna o ile zwieksza sie z czasem frustracja
    public float incTime;           //zmienna czasu 
    public float prcFrustration;    //zmienna procentowa frustracji
    public float prcDecision;       //zmienna procentowa decyzji

    void Start()
    {
        //wczytywanie obiektów tekstowych
        GameObject findFrustration = GameObject.FindWithTag("Frustration");
        if (findFrustration != null)
        {
            Debug.Log("LOAD :: Zaladowane Frustration Object");
            frustrationLevel = findFrustration.GetComponent<Text>();
            frustrationLevel.text = "Frustration: " + levelFrustration;
        }
        GameObject findDecision = GameObject.FindWithTag("Decision");
        if (findDecision != null)
        {
            Debug.Log("LOAD :: Zaladowane Decision Object");
            decisionLevel = findDecision.GetComponent<Text>();
            decisionLevel.text = "Decision: " + levelDecision;
        }
        //wczytywanie obiektow image
        GameObject findFrustrationBar = GameObject.FindWithTag("FrustrationBar");
        if (findFrustrationBar != null)
        {
            Debug.Log("LOAD :: Zaladowanie Frustration Bar");
            frustrationBar = findFrustrationBar.GetComponent<Image>();
        }
        GameObject findDecisionBar = GameObject.FindWithTag("DecisionBar");
        if (findDecisionBar != null)
        {
            Debug.Log("LOAD :: Zaladowanie Decision Bar");
            decisionBar = findDecisionBar.GetComponent<Image>();
        }
        
        //startowe wartości
        levelFrustration = 0;   //frustracja na 0
        levelDecision = 0;      //zdecydowanie na 0

        StartCoroutine(FrustrationINC());       //korutyna ktora zwieksza frustracje
        StartCoroutine(UpdateBars());           //korutyna ktora aktualizuje paski postepu

    }

    IEnumerator UpdateBars()
    {
        while (true)
        {
            yield return new WaitForSeconds(incTime);
            prcFrustration = levelFrustration / maxlevelFrustration;
            prcDecision = levelDecision / maxlevelDecision;
            Debug.Log("UPDT :: Frustracja % = " + prcFrustration + " Zdecydowanie % = " + prcDecision);
            decisionBar.fillAmount =prcDecision;
            frustrationBar.fillAmount = prcFrustration;
            if (levelFrustration >= maxlevelFrustration)
                break;
        }
    }

    IEnumerator FrustrationINC()
    {
        while (true)
        {
            yield return new WaitForSeconds(incTime);
            levelFrustration = incFrustration + levelFrustration;
            frustrationLevel.text = "Frustration: " + levelFrustration + "/" + maxlevelFrustration;
            //Debug.Log("CORUT :: Niby zwieksza frustracje");
            if (levelFrustration >= maxlevelFrustration)
                break;
        }
    }
}
