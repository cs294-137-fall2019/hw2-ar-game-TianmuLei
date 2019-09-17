using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{


  public static float debounceTime = 0.3f;
  public static bool freeze=false;

  public static int[] boardStatus = {0,0,0,0,0,0,0,0,0};
  public static void setSquare(string name){
    //Debug.Log(name);
    char last = name[name.Length - 1];
    int index = last - '0'-1;
    //Debug.Log(index);
    boardStatus[index]=1;
    return;
  }

  public static int slotRemain(){
    int slot=0;
    for(int i=0;i<9;i++){
      if(boardStatus[i]==0){
        slot++;
      }
    }
    return slot;

  }

  public static int placeCircle(){
    List<int> slot = new List<int>();
    for(int i=0;i<9;i++){
      if(boardStatus[i]==0){
        slot.Add(i);
      }
    }
    System.Random rnd = new System.Random();
    int next=rnd.Next(slot.Count);
    boardStatus[slot[next]]=-1;
    return slot[next];
  }

  public static int checkWin(){
    if(boardStatus[0]+boardStatus[1]+boardStatus[2]==3
        || boardStatus[3]+boardStatus[4]+boardStatus[5]==3
        || boardStatus[6]+boardStatus[7]+boardStatus[8]==3
        || boardStatus[0]+boardStatus[3]+boardStatus[6]==3
        || boardStatus[1]+boardStatus[4]+boardStatus[7]==3
        || boardStatus[2]+boardStatus[5]+boardStatus[8]==3
        || boardStatus[0]+boardStatus[4]+boardStatus[8]==3
          || boardStatus[2]+boardStatus[4]+boardStatus[6]==3){
            return 1;
          }

          if(boardStatus[0]+boardStatus[1]+boardStatus[2]==-3
              || boardStatus[3]+boardStatus[4]+boardStatus[5]==-3
              || boardStatus[6]+boardStatus[7]+boardStatus[8]==-3
              || boardStatus[0]+boardStatus[3]+boardStatus[6]==-3
              || boardStatus[1]+boardStatus[4]+boardStatus[7]==-3
              || boardStatus[2]+boardStatus[5]+boardStatus[8]==-3
              || boardStatus[0]+boardStatus[4]+boardStatus[8]==-3
                || boardStatus[2]+boardStatus[4]+boardStatus[6]==-3){
                  return -1;
                }

          return 0;

  }
}
