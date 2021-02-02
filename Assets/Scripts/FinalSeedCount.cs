using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalSeedCount : MonoBehaviour
{
    public Text seedText;
    public Text rewardMessage;
    // Start is called before the first frame update
    void Start()
    {
        seedText.text = $"{GameController.playerSeedsTotal}/12";
        rewardMessage.text = Message();
    }

    string Message()
    {
        string msg;
        switch (GameController.playerSeedsTotal)
        {
            case 0:
                msg = "IMPRESSIVE INCOMPETENCE!";
                break;
            case 1:
            case 2:
            case 3:
                msg = "SEED SHORTAGE!";
                break;
            case 4:
            case 5:
            case 6:
                msg = "SATISFACTORY SEEDAGE!";
                break;
            case 7:
            case 8:
            case 9:
                msg = "BOUNTIFUL HARVEST!";
                break;
            case 10:
            case 11:
                msg = "SEED HOARDER!";
                break;
            case 12:
                msg = "TRUE CROP KING!!";
                break;
            default:
                msg = "HOW??";
                break;
        }
        return msg;
    }
}
