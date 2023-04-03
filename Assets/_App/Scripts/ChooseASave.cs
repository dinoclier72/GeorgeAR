using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseASave : MonoBehaviour
{
    private SaveButtonGroup saveButtonGroup;
    [SerializeField]private Button nextButton;
    [SerializeField]private Button previousButton;
    [SerializeField]private Button buttonTemplate;
    [SerializeField]private Canvas canvas;
    private Dictionary<Button, string> saveButtonDictionary;
    private string selectedSave;

    void Awake(){
        SaveButtonGroup saveButtonGroup;
        buttonTemplate.gameObject.SetActive(false);
        float height = buttonTemplate.GetComponent<RectTransform>().rect.height*canvas.scaleFactor;
        saveButtonDictionary = new Dictionary<Button, string>();
        nextButton.onClick.AddListener(goNext);
        previousButton.onClick.AddListener(goPrevious);
        string[] saveFiles = Directory.GetFiles(Application.dataPath + "/_App/saves");
        List<string> saveFilesL = new List<string>();
        foreach(string saveFile in saveFiles){
            if(!saveFile.EndsWith(".meta")){
                saveFilesL.Add(saveFile);
            }
        }
        saveFiles = saveFilesL.ToArray();
        List<Button> buttonList = new List<Button>();;
        for(int i = 0; i < saveFiles.Length; i++){
            if((i+1)%5 == 1){
                buttonList.Clear();
            }
            Button button = Instantiate(buttonTemplate, transform);
            saveButtonDictionary.Add(button, saveFiles[i]);
            button.transform.Find("Text").GetComponent<TMP_Text>().text = Path.GetFileNameWithoutExtension(saveFiles[i]);
            button.onClick.AddListener(() =>{
                selectedSave = saveButtonDictionary[button];
            });
            button.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, (float)((i%5) * (height*1.25)));
            buttonList.Add(button);
            if((i+1) % 5 == 0){
                saveButtonGroup = new SaveButtonGroup(buttonList.ToArray());
                if(this.saveButtonGroup != null){
                    saveButtonGroup.setPreviousGroup(this.saveButtonGroup);
                    this.saveButtonGroup.setNextGroup(saveButtonGroup);
                }
                this.saveButtonGroup = saveButtonGroup;
            }
        }
        if(buttonList != null){
            saveButtonGroup = new SaveButtonGroup(buttonList.ToArray());
            if(this.saveButtonGroup != null){
                saveButtonGroup.setPreviousGroup(this.saveButtonGroup);
                this.saveButtonGroup.setNextGroup(saveButtonGroup);
            }
            this.saveButtonGroup = saveButtonGroup;
        }
        while(this.saveButtonGroup.getPreviousGroup() != null){
            this.saveButtonGroup = this.saveButtonGroup.getPreviousGroup();
        }
        this.saveButtonGroup.setActive(true);
        UpdataNavigationButtons();
    }

    void goNext(){
        saveButtonGroup.setActive(false);
        saveButtonGroup = saveButtonGroup.getNextGroup();
        saveButtonGroup.setActive(true);
        UpdataNavigationButtons();
    }

    void goPrevious(){
        saveButtonGroup.setActive(false);
        saveButtonGroup = saveButtonGroup.getPreviousGroup();
        saveButtonGroup.setActive(true);
        UpdataNavigationButtons();
    }

    void UpdataNavigationButtons(){
        if(saveButtonGroup.getNextGroup() == null){
            nextButton.gameObject.SetActive(false);
        }else{
            nextButton.gameObject.SetActive(true);
        }
        if(saveButtonGroup.getPreviousGroup() == null){
            previousButton.gameObject.SetActive(false);
        }else{
            previousButton.gameObject.SetActive(true);
        }
    }
}

public class SaveButtonGroup{
    private Button[] saveButtons;
    private SaveButtonGroup nextGroup;
    private SaveButtonGroup previousGroup;
    public SaveButtonGroup(Button[] saveButtons){
        this.saveButtons = saveButtons;
    }
    public void setNextGroup(SaveButtonGroup nextGroup){
        this.nextGroup = nextGroup;
    }
    public void setPreviousGroup(SaveButtonGroup previousGroup){
        this.previousGroup = previousGroup;
    }
    public SaveButtonGroup getNextGroup(){
        return nextGroup;
    }
    public SaveButtonGroup getPreviousGroup(){
        return previousGroup;
    }
    public Button[] getSaveButtons(){
        return saveButtons;
    }

    public void setActive(bool active){
        foreach(Button button in saveButtons){
            button.gameObject.SetActive(active);
        }
    }
}