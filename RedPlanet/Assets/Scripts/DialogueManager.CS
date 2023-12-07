using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class LoadData
    {
        public DialogueData[] dialogueList;
    }

    int counter = 0;
    public Text text;
    public Text place_text;
    public GameObject item_ui_object;
    Image item_image;
    LoadData data;

    bool isAnimation = false;

    void Load() {
        string inputString ="";
        if(SceneLoader.selected_prefecture == "Tokyo") {
            inputString = Resources.Load<TextAsset>("text Tokyo").ToString();
            place_text.text = "東京";
            
        }
        else if(SceneLoader.selected_prefecture == "Tanegashima") {
            inputString = Resources.Load<TextAsset>("text Tanegashima").ToString();
            place_text.text = "種子島";
        }else if(SceneLoader.selected_prefecture == "Aiti") {
            inputString = Resources.Load<TextAsset>("text Aiti").ToString();
            place_text.text = "愛知";
        }else if(SceneLoader.selected_prefecture == "Hyogo") {
            inputString = Resources.Load<TextAsset>("text Hyogo").ToString();
            place_text.text = "兵庫";
        
        }else if(SceneLoader.selected_prefecture == "Gunma") {
            inputString = Resources.Load<TextAsset>("text Gunma").ToString();
            place_text.text = "群馬";
        }
        else{
            inputString = Resources.Load<TextAsset>("text Start").ToString();
            place_text.text = "種子島";
        }
        data = JsonUtility.FromJson<LoadData>(inputString);

    }

    void Start() {
        item_image = item_ui_object.GetComponent<Image>();
        Load();
        StartCoroutine("StartDialogue");
    }

    void Next(){
        counter++;
        UpdateDialogue();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if(isAnimation) {
                StopAnimation();
            }
            else {
                Next();
            }
        }
    
}

void SetDialogue(int number) {
    text.text = data.dialogueList[number].text;
}

void StopAnimation() {
    StopCoroutine("StartDialogue");
    isAnimation = false;
    text.text = data.dialogueList[counter].text;
}

void UpdateDialogue() {
    if(data.dialogueList.Length > counter)
    {
        SetDialogue(counter);
        StartCoroutine("StartDialogue");
    }else if(SceneLoader.selected_prefecture == "Tanegashima"){
        SceneManager.LoadScene("EndScene");
    }else {
        SceneManager.LoadScene("MapScene");
    }
}

void ShowItemImage() {
    item_ui_object.SetActive(true);
    item_image.sprite = Resources.Load<Sprite>(data.dialogueList[counter].file);
}
void HideItemImage() {
    item_ui_object.SetActive(false);
}

private IEnumerator StartDialogue() {
    isAnimation = true;
    string dialogue = data.dialogueList[counter].text;
    if(data.dialogueList[counter].type == "image"){
        ShowItemImage();
    }
    for (int i = 0; i < dialogue.Length+1; i++)
    {
        text.text = dialogue.Substring(0,i);
        yield return new WaitForSeconds(.05f);
    }
    isAnimation = false;
}
}