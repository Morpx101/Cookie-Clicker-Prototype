using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class GameManegerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
        [SerializeField] TextMeshProUGUI cookietext;
        [SerializeField] int Cookies;

        [SerializeField] Animator canvasAnimator;

    [SerializeField] int WinTarget = 100;

    [SerializeField] int grandmaCount;      
    [SerializeField] int GrandmaCost;
    [SerializeField] TextMeshProUGUI Grandma_upgrade_cost;  
    // int cookie;

    float timer;

  private void Start()
    {
        Grandma_upgrade_cost.text = GrandmaCost.ToString();
    }



    private void Update()
    {
        if (grandmaCount > 0)
        {
            if (timer >= 1)
            {
                timer = 0;
                Cookies += grandmaCount;   // en cookie per grandma, varje sekund
                cookietext.text = Cookies.ToString();

                CheckWinCondition();
            }
            timer += Time.deltaTime;
        }
    }


    public void CookieClicker()
    {
            Cookies++;
            cookietext.text = Cookies.ToString();
            Debug.Log(Cookies);
            canvasAnimator.SetTrigger("Cookie_Shake");

        CheckWinCondition();
    }

    public void BuyGrandma()
    {
        if (Cookies >= GrandmaCost)
        {
            Cookies -= GrandmaCost;       
            grandmaCount++;               
            GrandmaCost = Mathf.RoundToInt(GrandmaCost * 1.15f);

            cookietext.text = Cookies.ToString();
            Grandma_upgrade_cost.text = GrandmaCost.ToString();  
        }
    }

    void CheckWinCondition()
    {
        if (Cookies >= WinTarget)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }




}

   
    