using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUIController : MonoBehaviour
{
	[Header("Top UI")]
	[SerializeField] private Image playerLeftImage;
	[SerializeField] private Image playerRightImage;
	[Space]
	[SerializeField] private Sprite playerAliveSprite;
	[SerializeField] private Sprite playerParasiteSprite;
	[Space]
	[SerializeField] private Image[] playerLeftHealthImages;
	[SerializeField] private Image[] playerRightHealthImages;
	[Space]
	[SerializeField] private Image powerLeftIndicationImage;
	[SerializeField] private Image powerRightIndicationImage;
	[Space]
	[SerializeField] private TextMeshProUGUI timerText;

	// jei noresim vietoj timerio ar kaip tasku pasiskiartyam rodyti su bar
	//[SerializeField] private Image progressImage;

	[Header("Round Change objs")]
	[SerializeField] private GameObject RoundChangeObj;
	[Space]
	[SerializeField] private Image playerChangeLeftImage;
	[SerializeField] private Image playerChangeRightImage;

	[Header("Variables")]
	private bool parasiteLeft;

	// -------------------------------------------------

	public void Initialize()
	{
		parasiteLeft = true;

		SetTopUI(parasiteLeft);

		SetBottomUI();
	}

	public void SetTopUI(bool parasiteLeft)
	{
		for (int i = 0; i < 3; i++)
		{
			playerLeftHealthImages[i].gameObject.SetActive(true);
			playerRightHealthImages[i].gameObject.SetActive(true);
		}

		timerText.text = "60:00";

		if (parasiteLeft)
		{
			// uzkomentuota, kol nera assetu
			//playerLeftImage.sprite = playerParasiteSprite;
			//playerRightImage.sprite = playerAliveSprite;

			powerLeftIndicationImage.gameObject.SetActive(false);
			powerRightIndicationImage.gameObject.SetActive(true);
		}
		else
		{
			// uzkomentuota, kol nera assetu
			//playerLeftImage.sprite = playerAliveSprite;
			//playerRightImage.sprite = playerParasiteSprite;

			powerLeftIndicationImage.gameObject.SetActive(true);
			powerRightIndicationImage.gameObject.SetActive(false);
		}
	}

	public void UpdateHealthImages(int player1HP, int player2HP)
	{
		for (int i = 0; i < 3; i++)
		{
			playerLeftHealthImages[i].gameObject.SetActive(i + 1 <= player1HP);
			playerRightHealthImages[i].gameObject.SetActive(i + 1 <= player2HP);
		}
	}

	public void SetBottomUI()
	{
		// jei noresim vietoj timerio ar kaip tasku pasiskiartyam rodyti su bar
	}

	public void SwitchUI()
	{
		parasiteLeft = !parasiteLeft;

		SetTopUI(parasiteLeft);

		SetBottomUI();
	}

	public void ShowRoundChange(bool parasiteLeft)
	{
		if (parasiteLeft)
		{
			//playerChangeLeftImage.sprite = playerParasiteSprite;
			//playerChangeRightImage.sprite = playerAliveSprite;
		}
		else
		{
			//playerChangeLeftImage.sprite = playerAliveSprite;
			//playerChangeRightImage.sprite = playerParasiteSprite;
		}
	}
}
