using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; // janela de dialogo
    public Image profileSprite; // sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; // nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Vari�veis de controle
    public bool isShowing; // se a janela est� vis�vel
    private int index; //index das senten�as
    private string[] sentences;
    private string[] correntActorName;
    private Sprite[] actorSprite;


    private Player player;

    public static DialogueControl instance;
    
    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index <sentences.Length - 1)
            {
                index++;
                profileSprite.sprite = actorSprite[index];
                actorNameText.text = correntActorName[index];
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
                player.isPaused = false;
            }
        }
    }

   

    public void Speech(string[] txt, string[] actorName, Sprite[] actorProfile)
    {
        if(!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            correntActorName = actorName;
            actorSprite = actorProfile;
            profileSprite.sprite = actorSprite[index];
            actorNameText.text = correntActorName[index];
            StartCoroutine(TypeSentence());
            isShowing = true;
            player.isPaused = true;
        }
    }
}
