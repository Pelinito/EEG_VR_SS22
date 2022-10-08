using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// This script is attached to MusicCanvas (the child of MusicCanvasObject)
public class GameSceneMenus : MonoBehaviour
{
    // Menu Objects
    public GameObject instructionsMenu, recordMenu, quitrecordMenu, playRecordedMenu;
  
    public GameObject songPlayerObject;
    public GameObject experimentCanvas, musicCanvas;
    



    public TextMeshProUGUI changingText;
    

    private string _emptyText = " ";
    private bool _recording = false;
   

  
   // Get other scripts
   public AudioManager audioManager;
   public TaskManager taskManager;
   public SongPlayer songPlayer;
   public ExperimentManager experimentManager;
   


    //
    //
    // TO DO
    // - Tidy up the Debug.Log controls
    // - Create proper Instructions and be consistent
    // - Adjust the timing, conditions, button for the QuitRecord()
    // - Pull the notes from the List - taskManager.recordedNotes - and play it to the player: DONE
    // Make the random song work!!!!!!!: DONE

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        InstructionsButton();
    }

    // Update is called once per frame
    void Update()
    {
        if(instructionsMenu.activeSelf == false)
        {
            audioManager.MakeBeep(audioManager.inputString);
        }

        if(_recording)
        {
            
            taskManager.StoreNotes();
            
        }


        if(playRecordedMenu.activeSelf)     // Change the keys or add buttons
        {
            
            changingText.text = "Press P to play your song or Q to continue with the experiment";
            
            if(Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(taskManager.PlayRecordedNotes());

            }

            if(Input.GetKeyDown(KeyCode.Q))
            {     
                musicCanvas.SetActive(false);
                experimentCanvas.SetActive(true);

                //experimentManager.TextDisplay("This is the 2nd stage. Press Space Bar to start the trials. Remember, C for Yellow, M for Blue!", 30);

            }
            
            
        }
        
        if(experimentCanvas.activeSelf)
        {
            songPlayerObject.SetActive(true);
        }
            

    }

    public void NextButton() // The one says "Lets Go"
    {
        instructionsMenu.SetActive(false);
        changingText.text = "Free Play";
        recordMenu.SetActive(true);
    }

    public void InstructionsButton() // Non-existent right now. Should implement --- This is not doing anything at all lol
    {
        changingText.text = _emptyText;
        instructionsMenu.SetActive(true);
    }

    public void RecordButton()
    {
        changingText.text = "Recording...";
        instructionsMenu.SetActive(false);
        recordMenu.SetActive(false);       
        quitrecordMenu.SetActive(true);

        _recording = true;

    }

    public void QuitRecord()
    {
        quitrecordMenu.SetActive(false);
        _recording = false;
        
        for(var i = 0; i < taskManager.recordedNotes.Count; i++)
        {
            Debug.Log(taskManager.recordedNotes[i]);
        }
        playRecordedMenu.SetActive(true);
    }


}
