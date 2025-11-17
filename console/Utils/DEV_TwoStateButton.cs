using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

/// <summary>
/// Se pone este script sobre un button normal de TextMeshPro, 
/// asegurarse que no tenga mas de dos textmeshGUI como child
/// </summary>
[RequireComponent(typeof(Button))]
public class DEV_TwoStateButton : MonoBehaviour
{
    TextMeshProUGUI txt;
    [SerializeField] Image img;
    bool state;

    [Header("Opcion A")]
    [SerializeField] string textAToShow;
    [SerializeField] Sprite spriteAToShow;
    [SerializeField] UnityEvent UE_A_Option;

    [Header("Opcion B")]
    [SerializeField] string textBToShow;
    [SerializeField] Sprite spriteBToShow;
    [SerializeField] UnityEvent UE_B_Option;

    private void Start()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
        GetComponent<Button>().onClick.AddListener(OnClickButton);

        if (txt) txt.text = textAToShow;
        if (img) img.sprite = spriteAToShow;
        state = false;
    }

    void OnClickButton()
    {
        if (state)
        {
            UE_B_Option.Invoke();
            if (txt) txt.text = textAToShow;
            if (img) img.sprite = spriteAToShow;
            state = false;
        }
        else
        {
            UE_A_Option.Invoke();
            if(txt) txt.text = textBToShow;
            if (img) img.sprite = spriteBToShow;
            state = true;
        }
    }
}
