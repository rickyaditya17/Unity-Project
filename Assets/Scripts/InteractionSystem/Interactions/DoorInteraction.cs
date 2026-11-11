using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float speed = 2f;

    bool isOpen;
    Quaternion closedRotation;
    Quaternion opendRotation;

    void Start()
    {
        closedRotation = transform.localRotation;
        opendRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        Quaternion target = isOpen ? opendRotation : closedRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * speed);
    }

    public string GetPrompt()
    {
        return isOpen ? "Tutup PIntu [E]" : "Buka Pintu [E]";
    }

    public void Interact(GameObject interactor)
    {
        isOpen = !isOpen;
    } 
}