using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    
    public TaskManager taskManager;
    public AudioManager audioManager;
    public ExperimentManager experimentManager;

    public string [] notes = new string[] {"A", "S", "D", "F", "G", "H", "J"};
    public List<string> recordedNotes = new List <string> ();
    public List<string> songNotes = new List <string> ();
    public List<string> removedNotes = new List <string> (); 

    private string _lastNote;
    public string congruency;

    private bool _isBlock3;
    private bool _isiCurrent;

    



    void OnEnable()
    {
        recordedNotes = taskManager.recordedNotes;
        RemoveNote();
        RemoveNoteFromList();
                
    }
    
    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        _isBlock3 = experimentManager.isBlock3;
        
        _isiCurrent = experimentManager.isiCurrent;
    }

    public IEnumerator PlaySong()
    {
        
        for (var i = 0; i<songNotes.Count; i++)
        {
            audioManager.MakeBeep(songNotes[i]);
            yield return new WaitForSeconds(0.5f);
        }

              
        
        
    }

    public void RemoveNote() // Keeps the first 3 Notes from recordedNotes
    {
        for (var i = 0; i < 4; i++)
        {
            songNotes.Add(recordedNotes[i]);
        }

        _lastNote = recordedNotes[recordedNotes.Count - 1];
    }

    public void RemoveNoteFromList()
    {
        for (var a = 0; a < notes.Length; a++)
        {
            if(_lastNote != notes[a]) // If the _lastNote is not the same, it can be added to the removedNotes
            {
                removedNotes.Add(notes[a]);
            }

        }
    }

    public void CompleteSong() // 70% of the time, the last note should stay the same. Other times it is a random note. 
    {
        
        if(Random.value <= 0.6)
        {
            songNotes[3] = _lastNote;
            congruency = "Congruent";
            
        }

        else if (Random.value > 0.6)
        {
            int b = Random.Range(0, removedNotes.Count); 
                
            songNotes[3] = removedNotes[b];
            congruency = "Incongruent";
            
        }
            
        
        
    }
}
