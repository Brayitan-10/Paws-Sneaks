using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    private bool PycercaDia;
    private bool DialogoInicia;
    private int LineaMostrando;

    private float Tiempo = 0.05f;

    [SerializeField] private GameObject exclamacion;
    [SerializeField] private GameObject DialogoPanel;
    [SerializeField] private TMP_Text DialogoText;
    [SerializeField, TextArea(4, 6)] private string[] DialogoLinea;
    // Update is called once per frame
    void Update()
    {
        if (PycercaDia && Input.GetButtonDown("Fire1"))
        {
            if (!DialogoInicia)
            {
                StartDialogue();
            }
            else if (DialogoText.text == DialogoLinea[LineaMostrando])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                DialogoText.text = DialogoLinea[LineaMostrando];
            }
        }
    }
    private void StartDialogue()
    {
        DialogoInicia = true;
        DialogoPanel.SetActive(true);
        exclamacion.SetActive(false);
        LineaMostrando = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        LineaMostrando++;
        if (LineaMostrando < DialogoLinea.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            DialogoInicia = false;
            DialogoPanel.SetActive(false);
            exclamacion.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine()
    {
        DialogoText.text = string.Empty;

        foreach (char ch in DialogoLinea[LineaMostrando])
        {
            DialogoText.text += ch;
            yield return new WaitForSecondsRealtime(Tiempo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PycercaDia = true;
            exclamacion.SetActive(true);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PycercaDia = false;
            exclamacion?.SetActive(false);
        }
    }
}
