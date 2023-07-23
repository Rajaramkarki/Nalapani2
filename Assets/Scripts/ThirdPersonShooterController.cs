using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using StarterAssets;



public class ThirdPersonShooterController: MonoBehaviour
{
    //all the required components
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform BowProjectile;
    [SerializeField] private Transform spawnArrowPosition;


    //components used to access other variables
    private ThirdPersonController thirdPersonController; 
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;


    private void Awake()
    {
        //get all the required components from the character
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //finds the screen center point (i.e. the point we are aiming at)
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        //ray cast to shoot
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        
        if (starterAssetsInputs.aim)
        {
            //while aiming is true then activate the aiming camera, as it has higher priority. It becomes the active main camera
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetOnRotateMove(false);

            //lerp function to smoothen animation
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1),1f, Time.deltaTime * 10f));

            //faces forward when we are holding aim
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            //if the the player is no longer aiming then set the aiming camera to false
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetOnRotateMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (starterAssetsInputs.shoot)
        {
            //if the player presses shoot, instantiate an arrow object from the spawnpoint
            Vector3 aimDir = (mouseWorldPosition - spawnArrowPosition.position).normalized;
            Instantiate(BowProjectile, spawnArrowPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }

    }
}
