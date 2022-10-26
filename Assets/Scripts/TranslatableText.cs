using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TranslatableText : MonoBehaviour
{
    public Translator.StringId stringId;
	
	private Text textField;
	
	private void Awake()
	{
		textField = GetComponent<Text>();
	}
	
	public void Translate()
	{
		textField.text = Translator.GetInstance().GetLocalizedText(stringId);
	}
}
