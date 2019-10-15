using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    List<string> allDialog;
    int dialogIndex = 0;
    public string text;
    string[] words;
    float timer;
    public float delay = 0.1f;
    int textIndex = 0;
    int wordIndex = 0;
    int maxLettersPerLine = 30;
    public GameObject letterPrefab;
    public GameObject spawnPoint;
    public GameObject textPoint;

    List<GameObject> letters = new List<GameObject>();

    AudioSource sfx;

    bool canPass = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay){
            timer -= delay;
            if(wordIndex < words.Length){
                string word = words[wordIndex];

                if(textIndex < word.Length){
                    string lt = word.Substring(textIndex, 1);

                    Vector2 letterInfo = getLine(wordIndex);

                    GameObject letter = Instantiate(letterPrefab);
                    letter.GetComponent<Text>().text = lt;
                    letter.GetComponent<LetterSingle>().line = (int)letterInfo.x;
                    letter.GetComponent<LetterSingle>().pos = (int)letterInfo.y + textIndex;
                    letter.GetComponent<LetterSingle>().textStart = textPoint.transform.position;
                    letter.transform.SetParent(transform, false);
                    letter.transform.position = spawnPoint.transform.position;
                    letter.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                    textIndex ++;

                    letters.Add(letter);

                    sfx.PlayOneShot(sfx.clip);
                }
                else{
                    wordIndex++;
                    textIndex = 0;
                }
            }
            else{
                canPass = true;
            }
        }


        if(Input.GetKeyDown(KeyCode.E) && canPass){
            if(dialogIndex < allDialog.Count-1){
                NextDialog();
            }
            else{
                gameObject.SetActive(false);
                GlobalVars.inputBlocked = false;
            }
        }
    }

    public void ShowDialog(NPCCharacter character){
        this.allDialog = character.dialogs;
        GlobalVars.inputBlocked = true;
        canPass = false;
        dialogIndex = -1;
        gameObject.SetActive(true);
        NextDialog();
    }

    void NextDialog(){
        foreach(GameObject go in letters){
            Destroy(go);
        }
        textIndex = 0;
        wordIndex = 0;
        dialogIndex ++;
        text = allDialog[dialogIndex];
        words = text.Split(new char[]{' '});
    }

    Vector2 getLine(int wordIndex){
        int acc = 0;
        int line = 0;
        int pos = 0;

        for(int i = 0; i <= wordIndex; i ++){
            pos = acc;
            acc += words[i].Length;
            if(acc > maxLettersPerLine){
                acc = words[i].Length + 1;
                line ++;
                pos = 0;
            }
            else{
                acc++; //espaço
            }
        }


        return new Vector2(line, pos);
    }

}
