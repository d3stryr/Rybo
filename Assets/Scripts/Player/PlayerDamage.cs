using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private TMP_Text lifeTextScore;

    private int lifeScoreCount;

    private bool canDamage;
    // Start is called before the first frame update
    void Start()
    {
        lifeTextScore = GameObject.Find("LifeText").GetComponent<TMP_Text>();
        lifeScoreCount = 3;
        lifeTextScore.text = "x " + lifeScoreCount;

        canDamage = true;
    }

    public void DealDamage()
    {
        if(canDamage)
        {
            lifeScoreCount--;
            if(lifeScoreCount>0)
            {
                lifeTextScore.text = "x " + lifeScoreCount;
            }
            else
            {
                lifeTextScore.text = "x " + lifeScoreCount;
                Time.timeScale = 0f;
                StartCoroutine(RestartGame());
            }
            canDamage = false;

            StartCoroutine(WaitForDamage());
        }
        
    }
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//class end
