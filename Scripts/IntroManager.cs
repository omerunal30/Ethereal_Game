using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Text dialogueText;        // Diyalog yaz�s�
    public Image fadeImage;          // Fade i�in kullan�lacak siyah Image

    void Start()
    {
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        // Ba�lang��ta fadeImage opak olmal�
        fadeImage.color = new Color(0, 0, 0, 1);
        dialogueText.text = "";

        // Fade-in efekti (karanl�ktan ��k)
        yield return StartCoroutine(FadeImage(1f, 0f));

        // Metni g�ster
        yield return StartCoroutine(ShowText("Lomo (i� ses): Bu ormana gireli ka� y�l oldu bilmiyorum...", 3f));

        yield return StartCoroutine(ShowText("Lomo: Ama art�k Siyah G�l�e daha yak�n�m. Hissediyorum.", 3f));

        // Fade-out efekti (ekran� karart)
        yield return StartCoroutine(FadeImage(0f, 1f));

        

    }

    IEnumerator ShowText(string text, float duration)
    {
        // Altyaz� stilini ayarla
        dialogueText.fontSize = 10;
        dialogueText.alignment = TextAnchor.LowerCenter;
        dialogueText.color = Color.white;

        // G�lge/arka plan efekti yoksa iste�e ba�l� eklenebilir

        // Metni g�ster
        dialogueText.text = text;

        // Belirtilen s�re kadar g�ster
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

        fadeImage.color = new Color(c.r, c.g, c.b, toAlpha); // Biti� alfa
        fadeImage.gameObject.SetActive(false); // tamamen devre d��� b�rak�r

    }
}
