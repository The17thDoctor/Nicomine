using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPeople : MonoBehaviour
{
    private int sickPeople = 0;
    // Start is called before the first frame update
    void Start()
    {
        setDeadPeople(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDeadPeople(int number)
    {
        sickPeople = number;
    }
}
