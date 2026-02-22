using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinesVisuals : MonoBehaviour
{
    private Machines machines;

    private Animator machineAnimator;

    [SerializeField] private ParticleSystem soapParticle;

    private const string INTERACT = "Interact";

    private void Awake()
    {
        machines = GetComponent<Machines>();
        machineAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        machines.OnProductPassed += EmplooyesWorkSpace_OnProductPassed;
    }


    private void EmplooyesWorkSpace_OnProductPassed(object sender, System.EventArgs e)
    {

        machineAnimator.SetTrigger(INTERACT);

        if (soapParticle == null) return;

        soapParticle.Play();
    }
}
