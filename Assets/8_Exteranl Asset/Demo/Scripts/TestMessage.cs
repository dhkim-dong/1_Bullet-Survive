using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TestMessage : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    public GameObject myh;

    int myNum;
 
    private void Awake()
    {
        myh.gameObject.SetActive(false);

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("어느날 학원 앞에 놓여진 의문의 종이.", "Li", () => Show_Example(0))); 

        dialogTexts.Add(new DialogData("'뭐지 짭같이 생긴 이 명함은...'", "Li"));

        dialogTexts.Add(new DialogData("뒷면에는 짧은 글귀가 써져 있었다.", "Li"));

        dialogTexts.Add(new DialogData("/color:red/ /size:up//size:up//speed:down/ < 문어 게임에 오신 것을 환영합니다. >", "Li")); 

        dialogTexts.Add(new DialogData("'엥 문어? 갑자기?'", "Li")); 

        dialogTexts.Add(new DialogData("그렇게 손에 든 쓰레기 쪼가리를 버리려던 찰나,", "Li",  () => Show_Example(1)));

        dialogTexts.Add(new DialogData("나는 그대로 정신을 잃고 쓰러졌다.", "Li", () => Show_Example(2)));

        dialogTexts.Add(new DialogData("...", "Li"));

        dialogTexts.Add(new DialogData("???", "Li"));

        dialogTexts.Add(new DialogData("... 여기가 어디지.", "Li", () => Show_Example(3)));

        dialogTexts.Add(new DialogData("곧이어 스피커에서 울려 퍼지는 음성.", "Li"));

        dialogTexts.Add(new DialogData("/color:red/ /size:up//size:up/게임에 참가한 여러분 반갑습니다.", "Li"));
        
        dialogTexts.Add(new DialogData("/color:red/ /size:up//size:up/총알에 맞지 않고 생존한 시간만큼 돈을 드리겠습니다.", "Li"));

        dialogTexts.Add(new DialogData("/color:red/ /size:up//size:up/상금은 1초당 1억입니다.", "Li"));

        dialogTexts.Add(new DialogData("그렇다. 이것은 강남에 건물을 세울 기회다.", "Li"));

        dialogTexts.Add(new DialogData("/color:red/ /size:up//size:up/곧 게임이 시작됩니다.", "Li"));

        DialogManager.Show(dialogTexts);
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }

}
