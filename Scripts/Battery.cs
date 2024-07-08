using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [Header("Options")]
    [Tooltip("the battery the player gains when they collect this.")] [SerializeField] int batteryWeight;
    
    [SerializeField] KeyCode CollectKey = KeyCode.E;

    [Header("References")]
    [Tooltip("the object shown when player hovers over battery.")] [SerializeField] GameObject[] HoverObject;

    public void OnMouseOver(){

        foreach (GameObject obj in HoverObject) obj.SetActive(true);

        if(Input.GetKeyDown(CollectKey))
        {
            FindObjectOfType<Flashlight>().GainBattery(batteryWeight);

        }
    }

    public void OnMouseExit(){
        foreach (GameObject obj in HoverObject) obj.SetActive(false);

    }
}
