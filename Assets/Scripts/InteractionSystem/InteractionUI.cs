using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private PlayerInteraction player;
    [SerializeField] private TextMeshProUGUI promptText;

    void Update()
    {
        if (player.Current != null)
        {
            promptText.text = player.Current.GetPrompt();
            promptText.enabled = true;
        }
        else
        {
            promptText.enabled = false;
        }

    }
}
