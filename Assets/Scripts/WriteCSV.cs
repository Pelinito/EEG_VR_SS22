using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class WriteCSV : MonoBehaviour
{

    private string filename = "";


    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/Data/" + Guid.NewGuid() + ".csv";
    }

    public void MakeCSV(List<string> data, string header)
    {
        TextWriter csvFile = new StreamWriter(filename, false);
        csvFile.WriteLine(header);

        for (int i = 0; i < data.Count; i++)
        {
            csvFile.WriteLine(data[i]);
        }

        csvFile.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
