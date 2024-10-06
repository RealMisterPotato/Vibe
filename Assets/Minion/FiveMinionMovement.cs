using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class FiveMinionMovement : MonoBehaviour
{
    private CharacterController characterController;

    [@SerializeField]
    private GameObject target;
    [@SerializeField]
    private MinionInGroup[] minions;
    [@SerializeField]
    private float followSpeed = 5.2f;
    private float rotationSpeed = 8.0f;
    [@SerializeField]
    private float maxDistanceFromTarget = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.enabled = true;
        try{
            if (target == null) target = GameObject.Find("Character");
        }catch(Exception e){
            print(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        if (Vector3.Distance(this.transform.position, target.transform.position) > maxDistanceFromTarget){
            MoveForwards();
            for (int i = 0; i < minions.Length; i++){
                minions[i].SetRun();
            }
        }
        else{
            for (int i = 0; i < minions.Length; i++){
                minions[i].SetIdle();
            }
        }
    }
    private void RotateTowardsTarget(){
        // Determine which direction to rotate towards
        Vector3 targetPos = target.transform.position;
        Vector3 pos = transform.position;
        targetPos.y = 0;
        pos.y = 0;
        Vector3 targetDirection = targetPos - pos;

        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    private void MoveForwards(){
        characterController.Move(transform.TransformDirection(Vector3.forward * followSpeed * Time.deltaTime));
    }
}
