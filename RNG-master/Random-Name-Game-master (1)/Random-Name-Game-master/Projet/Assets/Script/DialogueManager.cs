using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DiaBox;
    public Text DText;
    public string[] DialogLines;
    public int currentLine;

    public bool DialogActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Update()
    {
        if (DialogActive && Input.GetKeyDown(KeyCode.L))
        {
            DiaBox.SetActive(false);
            DialogActive = false;
        }
        else
        {


            if (DialogActive && Input.GetKeyDown(KeyCode.M))
            {
                currentLine++;

            }

            if (currentLine>=DialogLines.Length)
            {
                DiaBox.SetActive(false);
                DialogActive = false;
                currentLine = 0;
            }

            DText.text = DialogLines[currentLine];
        }
    }

    public void showbox(string Dialogue)
    {
        DialogActive = true;
        DiaBox.SetActive(true);
        DText.text = Dialogue;

    }
}
