using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkUI : MonoBehaviour
{
    //public GameObject EventObj;
    public GameObject talkpanel;
    private int currentDialogueIndex = 0;

    [SerializeField]
    public int Count = 1;

    private Vector2 namepos;
    private Vector2 CGpos;
    public GameObject LeftNamepos;
    public GameObject RightNamepos;
    public GameObject LeftName;
    public GameObject RightName;
    public GameObject LeftCG;
    public GameObject RightCG;

    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private GameObject sprite_DialogueBox;
    [SerializeField] private TextMeshProUGUI txt_Dialogue;


    [SerializeField] public Dialogue[] dialogues;

    private void Start()
    {
        Count = 1;
        StartDialogue();
        //isAlignedRight = !isAlignedRight;
    }

    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Debug.Log("말해주세용");
            ContinueDialogue();
            Count++;
            /*
            if (Count == 2)
            {
                Debug.Log("리리카 대사 시작");
                EndDialogue();
            }

            if (Count == 3)
            {
                Debug.Log("슈벨 대사 시작");
                EndDialogue();
            }
            if (Count == 6)
            {
                EndDialogue();
            }
            */
        }
    }

    private void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            currentDialogueIndex = 0;
            DisplayDialogue();
        }
    }

    private void ContinueDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            DisplayDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayDialogue()
    {
        LeftorRight();
        Dialogue currentDialogue = dialogues[currentDialogueIndex];
        //Debug.Log("NPC: " + currentDialogue.npcText);
        // Debug.Log("Player: " + currentDialogue.playerText);

        txt_Dialogue.text = currentDialogue.Text;

    }

    private void EndDialogue()
    {
        talkpanel.gameObject.SetActive(false);
        GetComponent<EventManager>().animCount++;
        //SpaceCount++;
        GetComponent<TalkUI>().enabled = false;
    }
    private void LeftorRight()
    {
        if (dialogues[Count].left == true)
        {
            txt_Dialogue.alignment = TMPro.TextAlignmentOptions.Left;
            namepos = LeftNamepos.transform.position;
            CGpos = LeftCG.transform.position;
            sprite_StandingCG.transform.position = new Vector2(CGpos.x, CGpos.y);

            LeftName.gameObject.SetActive(true);
            RightName.gameObject.SetActive(false);

        }

        else
        {
            txt_Dialogue.alignment = TMPro.TextAlignmentOptions.Right;
            namepos = RightNamepos.transform.position;
            CGpos = RightCG.transform.position;
            sprite_StandingCG.transform.position = new Vector2(CGpos.x, CGpos.y);


            LeftName.gameObject.SetActive(false);
            RightName.gameObject.SetActive(true);
        }
    }
}



[System.Serializable]
public class Dialogue
{

    [TextArea]
    //public string npcText;
    public string Text;
    //public GameObject Targetposition;
    public Sprite cg;
    public bool left;
}

