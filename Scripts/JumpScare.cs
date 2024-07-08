using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
public AudioSource scream;
public GameObject ThePlayer;
public GameObject jumpScare;
//public GameObject flashImg;
[SerializeField] private GameObject Trigger;

void OnTriggerEnter()
{
    scream.Play();

    ThePlayer.SetActive(false);
    jumpScare.SetActive(true);
    //flashImg.SetActive(true);
    StartCoroutine(EndJump());
}

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(3.0f);
        ThePlayer.SetActive(true);
        jumpScare.SetActive(false);
        //flashImg.SetActive(false);
        Trigger.SetActive(false);
    }
}
