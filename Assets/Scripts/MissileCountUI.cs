using UnityEngine;
using TMPro;

public class MissileCountUI : MonoBehaviour
{
    public TextMeshProUGUI countText;

    private PlayerMissiles playerMissiles;

    private void Awake()
    {
        playerMissiles = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMissiles>();

        if (playerMissiles != null)
        { 
            playerMissiles.MissileCountChanged += UpdateText;
        }
    }

    private void UpdateText(int missileCount)
    {
        countText.text = missileCount.ToString();
    }
}
