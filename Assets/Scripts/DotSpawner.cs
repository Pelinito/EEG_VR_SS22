using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    
    public GameObject[] dotsToInstantiate; 
    

    // location randomization
    private float _x;
    private float _y;
    private float _min = -4;
    private float _max = 4;
    private GameObject _dot;  
    
    public int differenceRange;

   
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // yellowDots = GameObject.FindGameObjectsWithTag("YellowDot");
        // blueDots = GameObject.FindGameObjectsWithTag("BlueDot");
        
    }


    // TO DO: Randomize the size ! - Maybe not 
    // TO DO: Location !: DONE
    // TO DO: Avoid spawning on the same location and make the location more versatile: DONE

    // Dots will spawn differently every trial - with a button press. Consider that.
    public void SpawnDots()
    {
        int n = Random.Range(0, dotsToInstantiate.Length); // which dot to spawn more
        int m = Random.Range(5,21); // choosing the starting point to deviate - number of spawned dots

        // differenceRange so that there will no absurd imbalanced spawns e.g. 5 yellow 15 blue
        
        if(m >= 5 && m < 10)
        {
            differenceRange = 2;
        }
        else if(m >= 10 && m < 15)
        {
            differenceRange = 4;
        }
        else if(m > 15)
        {
            differenceRange = 5;
        }

        int moreToSpawn = Random.Range(m, m+differenceRange+1); // +1 to include the differed number in the Random.Range
        int lessToSpawn = Random.Range(m-differenceRange, m); // no m+1, we want to avoid the same number of spawns


        for (var i = 0; i < moreToSpawn; i++)
        {
            _x = Random.Range(_min, _max);
            _y = Random.Range(_min, _max);
            

            Instantiate(dotsToInstantiate[n], new Vector3(_x,_y,0), Quaternion.identity); 
            

        

        }
        for (var i = 0; i < lessToSpawn; i++)
        {
            _x = Random.Range(_min, _max);
            _y = Random.Range(_min, _max);
            

            Instantiate(dotsToInstantiate[dotsToInstantiate.Length - n - 1], new Vector3(_x,_y,0), Quaternion.identity);            
            
        
        }

        

        





    }

    
}
