using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCast : MonoBehaviour
{
    public Text cuentaAtrasTexto;
    public int cuentaAtrasDuracion = 5;
    [SerializeField] private string[] nombresObjetos;
    [SerializeField] private string[] nombresEscenas;
    private bool cuentaAtras = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < nombresObjetos.Length; i++)
                {
                    if (hit.transform.name == nombresObjetos[i] && !cuentaAtras)
                    {
                        StartCoroutine(CuentaAtras(nombresEscenas[i]));
                        break;
                    }
                }
            }
        }
    }

    IEnumerator CuentaAtras(string escenaDestino)
    {
        cuentaAtras = true;

        for (int i = cuentaAtrasDuracion; i >= 0; i--)
        {
            cuentaAtrasTexto.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        SceneManager.LoadScene(escenaDestino);
        cuentaAtras = false;
    }
}