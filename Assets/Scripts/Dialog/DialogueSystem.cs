using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialog;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private CharacterType type;
    private int index;
    private bool isInTurn;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&isInTurn)
        {
            Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)=>isInTurn=true;
    private void OnTriggerExit2D(Collider2D collision)=>isInTurn = false;
    private void Play()
    {
        print(gameObject);
        dialogBox.SetActive(true);
        DialogNode node = dialogue.dialogNodes[Mathf.Clamp(index++,0, dialogue.dialogNodes.Length-1)];
        dialog.text = node.characterName;
        if(index-1==dialogue.dialogNodes.Length)
        {
            dialogBox.SetActive(false);
        }
    }
    


}
