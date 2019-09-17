using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grid5 : MonoBehaviour, OnTouch3D
{
  public GameObject squareObject;
  public GameObject c1;
  public GameObject c2;
  public GameObject c3;
  public GameObject c4;
  public GameObject c5;
  public GameObject c6;
  public GameObject c7;
  public GameObject c8;
  public GameObject c9;
  public Text messageText;
  public float debounceTime = 0.3f;
  // Stores a counter for the current remaining wait time.
  private float remainingDebounceTime;
//  private bool placed;
  private List<GameObject> slot;
    // Start is called before the first frame update
    void Start()
    {
      remainingDebounceTime = 0.3f;
    //  placed=false;
      slot = new List<GameObject>();
      slot.Add(c1);
      slot.Add(c2);
      slot.Add(c3);
      slot.Add(c4);
      slot.Add(c5);
      slot.Add(c6);
      slot.Add(c7);
      slot.Add(c8);
      slot.Add(c9);
    }

    // Update is called once per frame
    void Update()
    {
      if (remainingDebounceTime > 0){
        remainingDebounceTime -= Time.deltaTime;
      }

    }

    public void endGame(int status){
      messageText.gameObject.SetActive(true);
      if(status==1){
        messageText.text = "You Win!";
      }
      else if(status==-1){
        messageText.text = "AI Win!";
      }
      else{
        messageText.text = "There is a tie!";
      }
      GameInfo.freeze=true;

    }



    public void OnTouch()
    {
        //messageText.gameObject.SetActive(true);
          //messageText.text = "AI Win the Game!";

          if (remainingDebounceTime <= 0&&!GameInfo.freeze)
          {
            char last = name[this.gameObject.name.Length - 1];
            int index = last - '0'-1;
            if(GameInfo.boardStatus[index]==0){
              this.squareObject.SetActive(true);
              remainingDebounceTime = debounceTime;
              GameInfo.setSquare(this.gameObject.name);

              int result=GameInfo.checkWin();
              if(result==1){
                endGame(result);
                return;
              }
              if(result==0&&GameInfo.slotRemain()==0){
                endGame(result);
                return;
              }



              if(GameInfo.slotRemain()>0){
                int indexToPlace=GameInfo.placeCircle();
                slot[indexToPlace].SetActive(true);

                result=GameInfo.checkWin();
                if(result==-1){
                  endGame(result);
                  return;
                }
                if(result==0&&GameInfo.slotRemain()==0){
                  endGame(result);
                  return;
                }
              }
            }
          }
    }

}
