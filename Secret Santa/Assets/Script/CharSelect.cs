using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour
{
    private int selectedCharIndex;
    private Color desiredColor;
    
    [Header("List Of Characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();
    
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI CharName;
    [SerializeField] private Image characSprite;
    [SerializeField] private Image backColor;

    [Header("Sound References")]
    [SerializeField] private AudioClip arrowClick;
    [SerializeField] private AudioClip CharSelectMusic;
    [SerializeField] private AudioClip CharSelectConfirm;

    [Header("Tweaks")]
    [SerializeField] private float colorspeed = 10.0f;
    
    
    private void Start() {
        UpdateCharSelection();
    }
    private void Update() {
        backColor.color = Color.Lerp(backColor.color, desiredColor, Time.deltaTime * colorspeed);
    }

    public void Confirm()
    {
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharIndex, characterList[selectedCharIndex].characterName));
    }

    public void LeftArrow()
    {
        selectedCharIndex--;
        if(selectedCharIndex < 0)
            selectedCharIndex = characterList.Count - 1;
        
        UpdateCharSelection();
    }
    public void RightArrow()
    {
        selectedCharIndex++;
        if(selectedCharIndex == characterList.Count)
            selectedCharIndex = 0;
        
        UpdateCharSelection();
        
    }
    private void UpdateCharSelection() //Select Character
    {
        //Splash, Name, Color.
        characSprite.sprite = characterList[selectedCharIndex].splash;
        CharName.text = characterList[selectedCharIndex].characterName;
        desiredColor = characterList[selectedCharIndex].characterColor;
        
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColor;
    }
}
