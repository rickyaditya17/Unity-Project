using UnityEngine;

public class okaget : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    
    void Update()
    {
        
    }

    public string GetPrompt()
    {
        return "Press E to interact";
    }

    public void Interact(GameObject interactor)
    {
        rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
    }
}
