using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyPeople : MonoBehaviour
{
    int healthyPeople = 0;
    // Start is called before the first frame update
    void Start()
    {
        setHealthyPeople(80);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setHealthyPeople(int number)
    {
        healthyPeople = number;
    }
}
