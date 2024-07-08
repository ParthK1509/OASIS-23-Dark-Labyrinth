using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AnimateHand : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public Animator animator;
    public InputActionProperty gripAnimation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue=pinchAnimation.action.ReadValue<float>();
        float gripValue=gripAnimation.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);
        animator.SetFloat("Grip",gripValue);
    }
}
