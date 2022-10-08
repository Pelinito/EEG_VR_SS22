using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDestroyer : MonoBehaviour
{
    public ExperimentManager experimentManager; 
    public float stimTime = 2.0f;

    private bool stim;
    private bool interstim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stimTime -= Time.deltaTime;
        // if(stimTime < 0.0)
        // {
        //     Destroy.(this.gameObject);
        //     stimTime = 2.0f;
        // }
        if((GameObject.FindGameObjectsWithTag("YellowDot").Length > 0 || GameObject.FindGameObjectsWithTag("BlueDot").Length > 0))
        {
            
            if(stimTime < 0.0)
            {
                Destroy(this.gameObject);
                stimTime = 2.0f;
            }

        }

        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M)) // When we get the response to the stimulus
        {
            Destroy(this.gameObject);
        }
        // else if(stimTime < 0.0)
        // {
        //     Destroy(this.gameObject);
        //     stimTime = 2.0f;
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "YellowDot" || collision.gameObject.tag == "BlueDot")
        {
            Destroy(collision.gameObject);
            
        }
    }
}
