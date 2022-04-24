using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    private TMP_Text coinTextScore;

    private int scoreCount = 0;

    private AudioSource audioManager;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<TMP_Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == MyTags.COIN_TAG)
        {
            ScoreIncrease();
            collision.gameObject.SetActive(false);
            
        }
    }
    public void ScoreIncrease()
    {
        audioManager.Play();
        scoreCount++;
        coinTextScore.text = "x " + scoreCount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
