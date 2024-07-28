using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HintController : MonoBehaviour
{
    [FormerlySerializedAs("hintTextGO")] [SerializeField]
    private TextMeshProUGUI hintTextGo;

    public void SetText(string text)
    {
        hintTextGo.text =  text;
    }
}
