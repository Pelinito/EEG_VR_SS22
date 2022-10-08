using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSprite : MonoBehaviour
{
    
    private float MoveSpeed = 5.0f;
    

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.up * MoveSpeed * Time.deltaTime;

       

        if(transform.position.y > 5)
        {
            Destroy(this.gameObject);
        }

       
        
        
    }
}
