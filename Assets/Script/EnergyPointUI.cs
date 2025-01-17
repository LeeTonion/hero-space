using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyPointUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;
    private void Update()
    {
        Energypoint();
    }
    private void Energypoint()
    {
        TextMeshProUGUI.text = Player.Instance.GetPointEnergy().ToString();
    }
}
