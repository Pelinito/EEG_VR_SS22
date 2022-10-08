using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    

    // Listing the tones
    public AudioClip beepA;
    public AudioClip beepB;
    public AudioClip beepC;
    public AudioClip beepD;
    public AudioClip beepE;
    public AudioClip beepF;
    public AudioClip beepG;
    public AudioSource audioSource;


    // Initialize the input for the MakeBeep()
    public string inputString;

   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
    void OnGUI()
    {
        Event e = Event.current;
        inputString = e.keyCode.ToString();
    }

    public void MakeBeep(in string inputString)
    {
        if(KeyCode.A.ToString().Equals(inputString))
        {
            BeepA();
            
        }
        if(KeyCode.S.ToString().Equals(inputString))
        {
            BeepB();
            
        }
        if(KeyCode.D.ToString().Equals(inputString))
        {
            BeepC();
        }
        if(KeyCode.F.ToString().Equals(inputString))
        {
            BeepD();
        }
        if(KeyCode.G.ToString().Equals(inputString))
        {
            BeepE();
        }
        if(KeyCode.H.ToString().Equals(inputString))
        {
            BeepF();
        }
        if(KeyCode.J.ToString().Equals(inputString))
        {
            BeepG();
        }
         
    }
    public void BeepA()
    {
        
        audioSource.PlayOneShot(beepA, 0.7f);
        
    }

    public void BeepB()
    {
        // if(Input.GetKeyDown(KeyCode.S))
        // {
        //     audioSource.PlayOneShot(beepB, 0.7f);
        // }
        audioSource.PlayOneShot(beepB, 0.7f);
    }

    public void BeepC()
    {
        audioSource.PlayOneShot(beepC, 0.7f);
        
    }

    public void BeepD()
    {
        audioSource.PlayOneShot(beepD, 0.7f);
        
    }
    public void BeepE()
    {
        audioSource.PlayOneShot(beepE, 0.7f);
        
    }

    public void BeepF()
    {
        audioSource.PlayOneShot(beepF, 0.7f);
        
    }

    public void BeepG()
    {
        audioSource.PlayOneShot(beepG, 0.7f);
        
    }

    
    
}
