using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    int score;
    public TextMeshProUGUI scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);

        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {   //Adding 1 to the score
            score++;
            //Destroying the coin
            Destroy(col.gameObject);
            //Transforming our score value to a text
            scoretxt.text = score.ToString();
            PlayerPrefs.SetInt("savedscore", score);



        }

    }

    
}
