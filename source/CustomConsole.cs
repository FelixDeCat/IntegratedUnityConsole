using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class CustomConsole : MonoBehaviour
{
    public static CustomConsole instance;

    public TextMeshProUGUI txt;

    [SerializeField] TextMeshProUGUI[] staticTexts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void LogStaticText(int index, string msg)
    {
        if (index >= instance.staticTexts.Length || index < 0) throw new System.Exception("Indice fuera de rango");
        instance.staticTexts[index].text = msg;
    }
    public static void LogStaticText(int index, string msg, Color color, bool bold = false)
    {
        if (index >= instance.staticTexts.Length || index < 0) throw new System.Exception("Indice fuera de rango");
        instance.staticTexts[index].text = msg.Bold(bold).Paint(color);
    }

    public static void Log(string message, bool jump = false)
    {
        instance.txt.text += "\n" + message.Jump(jump);
    }
    public static void Log(string message, Color color, bool jump = false, bool bold = false)
    {
        instance.txt.text += "\n" + message
            .Bold(bold)
            .Paint(color)
            .Jump(jump);
    }
}

public static class StringExtensions
{
    public static string Paint(this string text, Color color)
    {
        return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>";
    }
    public static string Bold(this string text, bool bold)
    {
        return $"{(bold ? "<b>" : "")}{text}{(bold ? "</b>" : "")}";
    }
    public static string Jump(this string text, bool separate)
    {
        return $"{(separate?"\n":"")}{text}{(separate ? "\n" : "")}";
    }
}

