using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class MinionInGroup : MonoBehaviour
{
    public GameObject idle;
    public GameObject drunk;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetRun(){

        idle.SetActive(false);
        drunk.SetActive(true);
    }
    public void SetIdle(){
        drunk.SetActive(false);
        idle.SetActive(true);
    }
}
