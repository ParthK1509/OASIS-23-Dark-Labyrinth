using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerScare : MonoBehaviour
{
    
    public GameObject scream;
    public GameObject ThePlayer;
    public GameObject jumpScare;
    //public GameObject flashImg;
    private bool triggered=true;

    private XRSocketInteractor socket;
    [SerializeField] private Animator scareAnim;
    [SerializeField] private GameObject nunModel;
    void Start()
    {
        
        socket = gameObject.GetComponent<XRSocketInteractor>();
        scareAnim.enabled=false;
        
        
    }
    void Update()
    {
        if (triggered)
        {if (socket.hasSelection) trigger();}
    }
    
    public void trigger()
    {
        
        

        ThePlayer.SetActive(false);
        nunModel.transform.position= new Vector3(-8.29f,-0.71f,-6.73f);
        nunModel.transform.rotation= Quaternion.Euler(-4.546f,-90.0f,0.0f);
        jumpScare.SetActive(true);
        scareAnim.enabled=true;
        scareAnim.SetBool("PlayScare",true);
        StartCoroutine(PlayAudio());
        //flashImg.SetActive(true);
        StartCoroutine(EndJump());
        
        triggered=false;

    }
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(4f);
        ThePlayer.SetActive(true);
        jumpScare.SetActive(false);
        //flashImg.SetActive(false);
        Destroy(nunModel);

    }
    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(0.001f);
        scream.SetActive(true);
    }
   
}
