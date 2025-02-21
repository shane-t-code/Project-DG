using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public Canvas combatCanvas;
    public Canvas aimCanvas;
    public PlayerMovement playerMovement;

    public float rotationSpeed;

    public Transform combatLookAt;
    public Transform aimLookAt;

    public GameObject thirdPersonCam;
    public GameObject combatCam;
    public GameObject aimCam;

    public CameraStyle currentStyle;

    public bool aiming = false;

    public enum CameraStyle
    {
        Basic,
        Combat,
        Aim
    }

    private void Start()
    {
        currentStyle = CameraStyle.Combat;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Switch Styles
        //if(Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        //if(Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Combat);
        if (Input.GetMouseButtonDown(1))
        {
            SwitchCameraStyle(CameraStyle.Aim);
            aimCanvas.enabled = true;
            aiming = true;
            combatCanvas.enabled = false;
            playerMovement.moveSpeed /= 2;
        }
        if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
            aimCanvas.enabled = false;
            combatCanvas.enabled = true;
            SwitchCameraStyle(CameraStyle.Combat);
            playerMovement.moveSpeed *= 2;
        }

        //Rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //Rotate player obj
        if(currentStyle == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 InputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (InputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, InputDir.normalized, Time.deltaTime * rotationSpeed);
        }
        else if(currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }
        else if (currentStyle == CameraStyle.Aim)
        {
            Vector3 dirToAimLookAt = aimLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToAimLookAt.normalized;

            playerObj.forward = dirToAimLookAt.normalized;
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        combatCam.SetActive(false);
        thirdPersonCam.SetActive(false);
        aimCam.SetActive(false);

        if(newStyle == CameraStyle.Basic) thirdPersonCam.SetActive(true);
        if (newStyle == CameraStyle.Combat) combatCam.SetActive(true);
        if (newStyle == CameraStyle.Aim) aimCam.SetActive(true);

        currentStyle = newStyle;
    }
}
