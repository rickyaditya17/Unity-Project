using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float range = 4.5f;
    [SerializeField] private LayerMask interactMask;

    public IInteractable Current { get; private set; }

    InputSystem_Actions controls;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        controls.Player.Interact.performed -= OnInteract;
        controls.Player.Disable();
    }

    void Update()
    {
        Current = null;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, range, interactMask))
        {
            Current = hit.collider.GetComponentInParent<IInteractable>();
        }
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        if (Current != null)
        {   
            Current.Interact(gameObject);
           
                
        }
    }
}