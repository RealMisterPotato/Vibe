using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    private CharacterController characterController;


    private bool W_pressed = false;
    private bool A_pressed = false;
    private bool S_pressed = false;
    private bool D_pressed = false;

    private Vector3 currentMousePosition = Vector3.zero;

    [@SerializeField]
    private float walkSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        SyncMovementKeysToFlags();

        // handle movement keys
        Vector3 v3 = Vector3.zero;
        if (W_pressed){
            v3.z += walkSpeed;
        }
        else if (S_pressed){

            v3.z -= walkSpeed;
        }
        if (D_pressed){
            v3.x += walkSpeed;
        }
        else if (A_pressed){

            v3.x -= walkSpeed;
        }

        // handle rotation
        transform.Rotate(Vector3.up * (Input.GetAxisRaw("Horizontal")/5.0f));
        // normalize vector
        v3.Normalize();
        v3 *= walkSpeed;
        
        // transform local v3 to wold v3
        v3 = transform.TransformDirection(v3);
        // apply gravity and movement
        v3.y -= 10;
        v3 *= Time.deltaTime;
        characterController.Move(v3);
    }

    private void SyncMovementKeysToFlags(){

        if (Input.GetKeyDown(KeyCode.W))
            W_pressed = true;
        else if (Input.GetKeyUp(KeyCode.W))
            W_pressed = false;
        if (Input.GetKeyDown(KeyCode.A))
            A_pressed = true;
        else if (Input.GetKeyUp(KeyCode.A))
            A_pressed = false;
        if (Input.GetKeyDown(KeyCode.S))
            S_pressed = true;
        else if (Input.GetKeyUp(KeyCode.S))
            S_pressed = false;
        if (Input.GetKeyDown(KeyCode.D))
            D_pressed = true;
        else if (Input.GetKeyUp(KeyCode.D))
            D_pressed = false;
    }
}
