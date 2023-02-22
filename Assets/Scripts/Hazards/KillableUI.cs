using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class KillableUI : MonoBehaviour
{
    public Killable killable;

    private TextMeshProUGUI healthText;

    private void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        if (killable != null)
        {
            killable.hitPointsChanged += UpdateText;
        }
    }

    private void Update()
    {
    }

    private void UpdateText(int hitPoints)
    {
        healthText.text = hitPoints.ToString();
    }
}
