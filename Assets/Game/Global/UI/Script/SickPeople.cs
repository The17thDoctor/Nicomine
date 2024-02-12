using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickPeople : MonoBehaviour
{
    private int sickPeople = 0;
    // Start is called before the first frame update
    void Start()
    {
        setSickPeople(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setSickPeople(int number)
    {
        sickPeople = number;
    }
}
