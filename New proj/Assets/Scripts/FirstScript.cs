using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FirstScript : MonoBehaviour
{

    FirstScript script = FindObjectOfType<FirstScript>();

    public void CallName(string name)
    {

        script.CallName("ada");

        Debug.Log("Hey " + name);
    }
    // Start is called before the first frame update
    void Start()

    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
