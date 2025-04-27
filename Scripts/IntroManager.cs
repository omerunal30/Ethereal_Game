using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Text dialogueText;        // Diyalog yazýsý
    public Image fadeImage;          // Fade için kullanýlacak siyah Image

    void Start()
    {
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        // Baþlangýçta fadeImage opak olmalý
        fadeImage.color = new Color(0, 0, 0, 1);
        dialogueText.text = "";

        // Fade-in efekti (karanlýktan çýk)
        yield return StartCoroutine(FadeImage(1f, 0f));

        // Metni göster
        yield return StartCoroutine(ShowText("Lomo (iç ses): Bu ormana gireli kaç yýl oldu bilmiyorum...", 3f));

        yield return StartCoroutine(ShowText("Lomo: Ama artýk Siyah Gül’e daha yakýným. Hissediyorum.", 3f));

        // Fade-out efekti (ekraný karart)
        yield return StartCoroutine(FadeImage(0f, 1f));

        

    }

    IEnumerator ShowText(string text, float duration)
    {
        // Altyazý stilini ayarla
        dialogueText.fontSize = 10;
        dialogueText.alignment = TextAnchor.LowerCenter;
        dialogueText.color = Color.white;

        // Gölge/arka plan efekti yoksa isteðe baðlý eklenebilir

        // Metni göster
        dialogueText.text = text;

        // Belirtilen süre kadar göster
        yield return new WaitForSeconds(duration);

        // Metni temizle
        dialogueText.text = "";
    }




    IEnumerator FadeImage(float fromAlpha, float toAlpha)
    {
        float duration = 1f;
        float elapsed = 0f;
        Color c = fadeImage.color;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, elapsed / duration);
            fadeImage.color = new Color(c.r, c.g, c.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(c.r, c.g, c.b, toAlpha); // Bitiþ alfa
        fadeImage.gameObject.SetActive(false); // tamamen devre dýþý býrakýr

    }
}
