using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExperimentManager : MonoBehaviour
{
   
   public GameObject experimentCanvas; 
   public GameObject musicCanvas;

   public Image fixationBackground;
   public Image instructionsBackground;
   
   // From other scripts
   public AudioManager audioManager;
   public TaskManager taskManager;
   public DotSpawner dotSpawner;
   public SongPlayer songPlayer;
   public WriteCSV writeCsv;
   

   // Data Save
    private string _header = "BlockNumber, TrialNumber, nrYellowDots, nrBlueDots, Response, ReactionTime, Congruency";
    private List<string> _data = new List<string>();
    
    private string _congruency;
    

    // Dot Arrays
    public GameObject[] yellowDots;
    public GameObject[] blueDots;
    private int _nrYellow;
    private int _nrBlue;

    // Stimulus, interstimulus variables
    public float stimTime = 2.0f;
    private float _stimTime; 
    public bool stimCurrent;


    public float isiTime; // inter stimulus interval
    private float _isiTime;
    public bool isiCurrent = false;

    // Define number of trials
    public int nrTrials;
    public int _nrTrials;
    // private int _nrTrials;
    private string _response;

    // Reaction time
    private float _startTrial;
    private float _rt;

    // Block tracker    
    public int nrBlocks;
    public bool isBlock1;
    public bool isBlock2;
    public bool isBlock3;
    

   public TextMeshProUGUI textTextDisplay;
   
   private string blockStr;
   
      
   

    // Start is called before the first frame update
    void Start()
    {
        //nrBlocks = 1;
        _isiTime = isiTime;
        _stimTime = stimTime;
        _nrTrials = nrTrials;
        isBlock1 = true;
        isBlock2 = false;
        isBlock3 = false;
        
        

    }

    // Update is called once per frame
    void Update()
    {

        yellowDots = GameObject.FindGameObjectsWithTag("YellowDot");
        blueDots = GameObject.FindGameObjectsWithTag("BlueDot");

        _nrYellow = yellowDots.Length;
        _nrBlue = blueDots.Length;

        if(Input.GetKeyDown(KeyCode.Space) && instructionsBackground.gameObject.activeSelf)
        {
            instructionsBackground.gameObject.SetActive(false);
        }
        //blockStr = "Block" + nrBlocks.ToString() + "Press space key when ready";

               
      
        if(isBlock1)
        {
            BlockOne();
            nrBlocks = 1;
        }
        if (isBlock2)
        {
            BlockTwo();
            nrBlocks = 2;
        }
        if(isBlock3)
        {
            BlockThree();
            nrBlocks = 3;
        }
        else if(!isBlock1 && !isBlock2 && !isBlock3)
        {
            TextDisplay("Experiment Has Ended", 50);
            EndExperiment();
        }
        

        
    }



   public void TextDisplay(string text, int size)
   {
    textTextDisplay.text = text;
    textTextDisplay.fontSize = size;
    textTextDisplay.color = new Color(1,1,1,1);
   }

   

    public void BlockOne()
    {   
        if(Input.GetKeyDown(KeyCode.Space))
            {
                                
                isiCurrent = true;
                stimCurrent = false;
                
            }

        if(isiCurrent == true && stimCurrent == false)  // interstimulus interval
        {
            _isiTime -= Time.deltaTime;
            //TextDisplay("+", 100); 
            fixationBackground.gameObject.SetActive(true);  
                        
                

            if(_isiTime < 0.0)   // If ISI ended
            {
                
                isiCurrent = false;
                stimCurrent = true;

                _isiTime = isiTime; // reset the ISI time

                // dotSpawner.SpawnDots();
                // fixationBackground.gameObject.SetActive(false);
                StartCoroutine(ShowDots());
                    
                    
            }
        }

        if(isiCurrent == false && stimCurrent == true)  // stimulus interval
        {
            
            //TextDisplay(" ", 100);
            _startTrial = Time.realtimeSinceStartup;    // this marks the time when trial started
                
                
            _stimTime -= Time.deltaTime; 

            if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M))  // C for yellow, M for Blue
            {
                isiCurrent = true;
                stimCurrent = false;
                _stimTime = stimTime;  // reset the SI time

                if(Input.GetKeyDown(KeyCode.C))
                {
                    _response = "Yellow";
                }

                else if(Input.GetKeyDown(KeyCode.M))
                {
                    _response = "Blue";
                }               
                _rt = Time.realtimeSinceStartup - _startTrial;

                        

                _nrTrials -= 1;  
                SaveResponse();   
                              

            }

            else if(_stimTime < 0.0)
            {
                _response = "noResponse";

                isiCurrent = true;
                stimCurrent = false;
                _stimTime = stimTime;  // reset the SI time

                _rt = 0.0f;
                SaveResponse();
                    
                    

            }

            if(_nrTrials == -1)
            {
                taskManager.PlayRecordedNotes();
            }

            

        }
        
        if(_nrTrials < 0)
        {
            //TextDisplay("Block 2", 50);
            
            isBlock1 = false;
            isBlock2 = true;
            _nrTrials = nrTrials;
            //nrBlocks += 1;
            isiCurrent = true;
            stimCurrent = false;
            
        }
    }

        
        
    
    public void BlockTwo()
    {
        
        if(isiCurrent == true && stimCurrent == false)  // interstimulus interval
        {
            _isiTime -= Time.deltaTime;
            //TextDisplay("+", 100);
            //StartCoroutine(taskManager.PlayRecordedNotes());
            fixationBackground.gameObject.SetActive(true);  
            //dotSpawner.SpawnDots();
            
                            
                

            if(_isiTime < 0.0)   // If ISI ended
            {
                //TextDisplay(" ", 100);
                isiCurrent = false;
                stimCurrent = true;

                _isiTime = isiTime; // reset the ISI time
                StartCoroutine(ShowDots());
                //dotSpawner.SpawnDots();
                //fixationBackground.enabled = false;
                    
            }
        }

        if(isiCurrent == false && stimCurrent == true)  // stimulus interval
        {
        
            //TextDisplay(" ", 100);
            _startTrial = Time.realtimeSinceStartup;    // this marks the time when trial started
                
                
            _stimTime -= Time.deltaTime; 
           // StartCoroutine(taskManager.PlayRecordedNotes()); 


            if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M))  // C for yellow, M for Blue
            {
                isiCurrent = true;
                stimCurrent = false;
                Debug.Log("Key Pressed");
                _stimTime = stimTime;  // reset the SI time

                if(Input.GetKeyDown(KeyCode.C))
                {
                    _response = "Yellow";
                    
                }

                else if(Input.GetKeyDown(KeyCode.M))
                {
                    _response = "Blue";
                     
                }               
                _rt = Time.realtimeSinceStartup - _startTrial;

                        

                _nrTrials -= 1; 
                SaveResponse();  

                if(_nrTrials > -1) 
                {
                    StartCoroutine(taskManager.PlayRecordedNotes());
                }

                if(_nrTrials == -1)
                {
                    songPlayer.CompleteSong();
                    StartCoroutine(songPlayer.PlaySong());

                }

                 
                              

            }

            else if(_stimTime < 0.0)
            {
                _response = "noResponse";

                isiCurrent = true;
                stimCurrent = false;
                _stimTime = stimTime;  // reset the SI time

                _rt = 0.0f;
                StartCoroutine(taskManager.PlayRecordedNotes()); 
                SaveResponse();
                    
                    

            }

            

        }

        if(_nrTrials < 0)
        {           
           
            isBlock2 = false;
            isBlock3 = true;
            _nrTrials = nrTrials;
            isiCurrent = true;
            stimCurrent = false;
            
        }
    }

   
    public void BlockThree()
    {
        
        if(isiCurrent == true && stimCurrent == false)  // interstimulus interval
        {
            _isiTime -= Time.deltaTime;
            //TextDisplay("+", 100); 
            fixationBackground.gameObject.SetActive(true);  
            //dotSpawner.SpawnDots();
                                    
                

            if(_isiTime < 0.0)   // If ISI ended
            {
                isiCurrent = false;
                stimCurrent = true;

                _isiTime = isiTime; // reset the ISI time
                //dotSpawner.SpawnDots();
                //fixationBackground.enabled = false;
                StartCoroutine(ShowDots());
                    
                    
            }
        }

        if(isiCurrent == false && stimCurrent == true)  // stimulus interval
        {
                     // spawn the dots for the stimulus interval
            //TextDisplay(" ", 100);
            _startTrial = Time.realtimeSinceStartup;    // this marks the time when trial started
                
                
            _stimTime -= Time.deltaTime; 

            if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M))  // C for yellow, M for Blue
            {
                isiCurrent = true;
                stimCurrent = false;
                Debug.Log("Key Pressed");
                _stimTime = stimTime;  // reset the SI time

                if(Input.GetKeyDown(KeyCode.C))
                {
                    _response = "Yellow";
                    //songPlayer.CompleteSong();
                    //StartCoroutine(songPlayer.PlaySong());
                }

                else if(Input.GetKeyDown(KeyCode.M))
                {
                    _response = "Blue";
                    
                }               
                _rt = Time.realtimeSinceStartup - _startTrial;

                        

                _nrTrials -= 1;  
                SaveResponse(); 

                if(_nrTrials > -1)
                {
                songPlayer.CompleteSong();
                StartCoroutine(songPlayer.PlaySong());  
                }
                              

            }

            else if(_stimTime < 0.0)
            {
                _response = "noResponse";
                SaveResponse();

                isiCurrent = true;
                stimCurrent = false;
                _stimTime = stimTime;  // reset the SI time

                _rt = Time.realtimeSinceStartup - _startTrial;
                songPlayer.CompleteSong();
                StartCoroutine(songPlayer.PlaySong());                  
                    
            }
            
        }

        if(_nrTrials < 0)
        {
            
            //TextDisplay("Experiment has ended", 50);  
            //textTextDisplay.text = "Experiment Has Ended";          
            //EndExperiment();
            isBlock3 = false;
            
        }
    }


    private void SaveResponse()
    {
       
        // To Save: More Spawned Dot Color, Response, ReactionTime, Congruency
        if(isBlock1 || isBlock2)
        {
            _congruency = "notApplicable";
        }
        else if(isBlock3)
        {
            _congruency = songPlayer.congruency;
        }
        
        string currData = (nrBlocks.ToString() + "," + _nrTrials.ToString() + "," + _nrYellow.ToString() + "," + _nrBlue.ToString() + "," + _response + "," + _rt.ToString() + "," + _congruency);


        

        _data.Add(currData);
    }

    private void EndExperiment()

    {
        writeCsv.MakeCSV(_data, _header);
        Application.Quit();

    }

    private IEnumerator ShowDots()
    {

        while(instructionsBackground.gameObject.activeSelf)
        {
            yield return null;
        }
        dotSpawner.SpawnDots();
        yield return new WaitForSeconds(0.2f);
        fixationBackground.gameObject.SetActive(false);

    }


   

   

   
        
        
}


