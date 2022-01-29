using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [Header("Top UI")]
    [SerializeField] private Image playerLeftImage;
    [SerializeField] private Image playerRightImage;
    [Space]
    [SerializeField] private Sprite playerAliveSprite;
    [SerializeField] private Sprite playerParasiteSprite;
    [Space]
    [SerializeField] private Image powerLeftIndicationImage;
    [SerializeField] private Image powerRightIndicationImage;

    //[Header("Bottom UI")]

    // -------------------------------------------------

    public void Initialize()
    {
        SetTopUI(true);
    }

    public void SetTopUI(bool parasiteLeft)
    {
        if (parasiteLeft)
        {
            //playerLeftImage.sprite = playerParasiteSprite;
            //playerRightImage.sprite = playerAliveSprite;

            powerLeftIndicationImage.gameObject.SetActive(false);
            powerRightIndicationImage.gameObject.SetActive(true);
        }
        else
        {
            //playerLeftImage.sprite = playerAliveSprite;
            //playerRightImage.sprite = playerParasiteSprite;

            powerLeftIndicationImage.gameObject.SetActive(true);
            powerRightIndicationImage.gameObject.SetActive(false);
        }
    }
}
