using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainRoomPuzzle : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public GameObject box1Still;
    public GameObject box2Still;
    public GameObject box3Still;


    public XRSocketInteractor holder1;
    public XRSocketInteractor holder2;
    public XRSocketInteractor holder3;

    public bool checkBox1(){
        if(holder1.selectTarget == null || box1 == null){
            return false;
        }
        return holder1.selectTarget.name == box1.name;
    }
    public bool checkBox2(){
        if(holder2.selectTarget == null || box2 == null){
            return false;
        }
        return holder2.selectTarget.name == box2.name;
    }
    public bool checkBox3(){
        if(holder3.selectTarget == null || box3 == null){
            return false;
        }
        return holder3.selectTarget.name == box3.name;
    }

    public void CheckPlacement()
    {
        Debug.Log("In checkplacement");
        if(checkBox1() && checkBox2() && checkBox3()){
            //Activate portal here
            box1.SetActive(false);
            box2.SetActive(false);
            box3.SetActive(false);

            box1Still.SetActive(true);
            box2Still.SetActive(true);
            box3Still.SetActive(true);
        }
        else{
            Debug.Log("Not Enough");
        }
    }
}
