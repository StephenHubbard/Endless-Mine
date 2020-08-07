using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Netherforge.dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        private GameObject thisDialogue;
        public GameObject nextDialogue;

        private void Start()
        {
            thisDialogue = this.gameObject;
        }

        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        public void disableDialogue()
        {
            thisDialogue.SetActive(false);
            nextDialogue.SetActive(true);
        }
    }
}
