using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCount;

    private Shaft _shaft => GetComponent<Shaft>();
    private void Update()
    {
        goldCount .text = _shaft.CurrentDeposit.CurrentGold.ToString();
    }
}
