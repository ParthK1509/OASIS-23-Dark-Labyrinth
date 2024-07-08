using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public enum FlashlightState
{
    Off,
    On,
    Dead
}

[RequireComponent(typeof(AudioSource))]
public class Flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("the speed at which the battery falls at")] [Range(0.0f,2f)] [SerializeField] float batterylossTick = 0.5f;
    [SerializeField] int startBattery = 100;
    public int currentBattery;
    public FlashlightState state;
    private bool flashlightIsOn;
    //[Tooltip("the key for turning on off flashlight")][SerializeField] KeyCode ToggleKey = KeyCode.F;
    [SerializeField] private InputActionReference toggleKey=null;
    
    [Header("References")]
    [SerializeField] GameObject FlashlightLight;
    [SerializeField] AudioClip FlashlightOnFX, FlashlightOffFX;

      void Start()
    {
        toggleKey.action.performed += ToggleFlashLight;
        currentBattery = startBattery;
        InvokeRepeating(nameof(LoseBattery),0, batterylossTick); // Loses the battery at a set interval of time

    }

    
    void Update()
    {
        // if(Input.GetKeyDown(ToggleKey)) ToggleFlashLight();

        //Flash Light on off
        if(state == FlashlightState.Off) FlashlightLight.SetActive(false);
        else if(state == FlashlightState.Dead) FlashlightLight.SetActive(false);
        else if(state == FlashlightState.On) FlashlightLight.SetActive(true);

        if(currentBattery <= 0 )
        {
            currentBattery = 0;
            state = FlashlightState.Dead;
            flashlightIsOn = false;
        }
    }
    public void GainBattery(int amount)
    {
        if(currentBattery == 0){
            state = FlashlightState.On;
            flashlightIsOn = true;
        }
        if(currentBattery + amount > startBattery)
            currentBattery  =  startBattery;
        else
            currentBattery += amount;

    }
    private void LoseBattery()
    {
        if(state == FlashlightState.On) currentBattery--;
    }

    private void ToggleFlashLight(InputAction.CallbackContext context)
    {
        flashlightIsOn = !flashlightIsOn;
        if(state == FlashlightState.Dead)
        {
        flashlightIsOn = false;
        }
        if(flashlightIsOn)
        { 
            if(FlashlightOnFX!=null) GetComponent<AudioSource>().PlayOneShot(FlashlightOnFX);

            state = FlashlightState.On;

        }
        else
        { 
            if(FlashlightOffFX!=null) GetComponent<AudioSource>().PlayOneShot(FlashlightOffFX);

            state = FlashlightState.Off;
        }
    }
}
