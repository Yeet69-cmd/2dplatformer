using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Getscore : MonoBehaviour
{

    public Text score;
    public Text Highscore;
        

      // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetInt("savedscore").ToString();
        Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();

        
    }
}
