using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    
    // Gather from the other scripts
    public AudioManager audioManager;

    public TextMeshProUGUI notesText;

    // Lists for the notes
    public string [] notes = new string[] {"A", "S", "D", "F", "G", "H", "J"};
    // private string [] _beepCodes = new string[] {"A", "B", "C", "D", "E", "F", "G"};
    public List<string> recordedNotes = new List <string> ();
    // public List<string> songNotes = new List <string> ();
    // public List<string> removedNotes = new List <string> ();

    private int _noteLimit;
      
    
    // Start is called before the first frame update
    void Start()
    {
        _noteLimit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StoreNotes()
    {
        if (_noteLimit < 4)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                recordedNotes.Add("A");
                _noteLimit += 1;
                
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                recordedNotes.Add("S");
                _noteLimit += 1;
                
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                recordedNotes.Add("D");
                _noteLimit += 1;
            }
            else if(Input.GetKeyDown(KeyCode.F))
            {
                recordedNotes.Add("F");
                _noteLimit += 1;
            }
            else if(Input.GetKeyDown(KeyCode.G))
            {
                recordedNotes.Add("G");
                _noteLimit += 1;
            }
            else if(Input.GetKeyDown(KeyCode.H))
            {
                recordedNotes.Add("H");
                _noteLimit += 1;
            }
            else if(Input.GetKeyDown(KeyCode.J))
            {
                recordedNotes.Add("J");
                _noteLimit += 1;
            }


        }
    }

    public IEnumerator PlayRecordedNotes() // Plays in GameSceneMenus -- might change. Does not matter there anymore, or DOES IT?????
    {
        for(var i = 0; i<recordedNotes.Count; i++)
        {
            
            audioManager.MakeBeep(recordedNotes[i]);
            yield return new WaitForSeconds(0.5f);

        }

    }

    

    
    
}
