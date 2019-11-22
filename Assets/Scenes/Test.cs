using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    List<int> intList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
       intList.Add(1);
       intList.Add(2);
       intList.Add(3);
       
       intList.RemoveAt(0);

       Debug.Log(intList.Count);
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    
}
