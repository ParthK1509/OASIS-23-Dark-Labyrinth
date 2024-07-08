using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioPlayer : MonoBehaviour
{
    public bool playSound=true;
    public float raycastDistance = 10f;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Transform player;
    void Update()
    {
        
        Ray ray = new Ray(transform.position, -transform.forward);
        Debug.DrawRay(transform.position, -transform.forward,Color.green);
        RaycastHit hit;
        if(playSound){
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                
                Debug.Log("FoundPlayer");
                PlayInstructionSound();

            }
        }
    }}

    void PlayInstructionSound()
    {


        
            sound.Play();
            playSound=false;
            
        
    }
}