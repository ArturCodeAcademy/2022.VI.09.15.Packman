using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private CollectableHandler _collectableHandler;
	[SerializeField] private TMP_Text _text;

	private void Start()
	{
		_collectableHandler.OnTotalScoreChanged += UpdateUI;
		UpdateUI(_collectableHandler.TotalScore);
	}

	private void UpdateUI(int score)
	{
		_text.text = $"Score: {score}";
	}

	private void OnDestroy()
	{
		_collectableHandler.OnTotalScoreChanged -= UpdateUI;
	}
}
