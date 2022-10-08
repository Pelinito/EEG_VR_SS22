using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteSpawner : MonoBehaviour
{
    public GameObject[] notesToInstantiate; 
    public GameObject musicCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(musicCanvas.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.J))
            {
                SpawnNotes();
            }
        }
    }

    public void SpawnNotes()
    {
        int n = Random.Range(0, notesToInstantiate.Length);

        Instantiate(notesToInstantiate[n], new Vector3(Random.Range(-7,7), -4, 0), Quaternion.identity);

    }
}
