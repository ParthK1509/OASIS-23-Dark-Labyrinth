using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GrabPose : MonoBehaviour
{
    public HandData rightHandPose;
    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;
    private Quaternion[] startingFingerRotation;
    private Quaternion[] finalFingerRotation;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(SetupPose);
        rightHandPose.gameObject.SetActive(false);
    }

 
    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.animator.enabled= false;
            SetHandDataValues(handData,rightHandPose);
            SetHandData(handData,finalHandPosition,finalHandRotation,finalFingerRotation);
        }
    }
    public void SetHandDataValues(HandData h1, HandData h2)
    {
        startingHandPosition=h1.root.localPosition;
        finalHandPosition=h2.root.localPosition;
        
        startingHandRotation=h1.root.localRotation;
        finalHandRotation=h2.root.localRotation;

        startingFingerRotation = new Quaternion[h1.fingerBones.Length];
        finalFingerRotation = new Quaternion[h1.fingerBones.Length];

        for (int i=0 ; i<h1.fingerBones.Length; i++)
        {
            startingFingerRotation[i]=h1.fingerBones[i].localRotation;
            finalFingerRotation[i]=h2.fingerBones[i].localRotation;
        }
        
    }

    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition=newPosition;
        h.root.localRotation=newRotation;

        for (int i=0;i<newBonesRotation.Length;i++)
        {
            h.fingerBones[i].localRotation=newBonesRotation[i];

        }    
    }   
}
