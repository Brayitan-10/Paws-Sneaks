//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System.Linq;

//public class corazonesUI : MonoBehaviour
//{
//    public List<Image> vidasAtom;
//    public GameObject vidasImagePrefact;
//    public GamerLife gamerLife;
//    public int indexActual;
//    public Sprite vidaLlena;
//    public Sprite vidaLVacia;
//    private void Awake()
//    {
//        gamerLife.cambioVida.AddListener(cambiarCorazones); 
//    }
//    private void cambiarCorazones(int vidaActual)
//    {
//        if (!vidasAtom.Any())
//        {
//            CrearVida(vidaActual);
//        }
//        else
//        {
//            CambiarVida(vidaActual);
//        }
//    }
//    private void CrearVida(int vidaActual)
//    {
//        for (int i = 0; i < vidaActual; i++)
//        {
//            GameObject corazon = Instantiate(vidasImagePrefact, transform);
//            vidasAtom.Add(corazon.GetComponent<Image>());
//        }
//    }
//    private void CambiarVida(int vidaActual)
//    {
//        if (vidaActual <= indexActual)
//        {
//            QuitarCorazon(vidaActual);
//        }
//        else
//        {
//            AgregarCorazon(vidaActual);
//        }
//    }
//    private void QuitarCorazon(int vidaActual)
//    {
//        for (int i = indexActual; i >= vidaActual ; i--)
//        {
//            indexActual = i;
//            vidasAtom[indexActual].sprite = vidaLVacia;
//        }
//    }
//    private void AgregarCorazon(int vidaActual)
//    {
//        for (int i = indexActual; i < vidaActual; i++)
//        {
//            indexActual = i;
//            vidasAtom[indexActual].sprite = vidaLlena;
//        }
//    }
//}
