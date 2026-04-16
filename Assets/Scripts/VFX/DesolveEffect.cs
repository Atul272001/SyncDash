using UnityEngine;

public class DesolveEffect : MonoBehaviour
{
    Renderer rend;
    Material mat;

    float dissolve = 0;

    [SerializeField] float speed = 2f;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    void OnEnable()
    {
        dissolve = 0;
        mat.SetFloat("_DissolveAmount", 0);
    }

    public void StartDissolve()
    {
        StartCoroutine(Dissolve());
    }

    System.Collections.IEnumerator Dissolve()
    {
        while (dissolve < 1)
        {
            dissolve += Time.deltaTime * speed;
            mat.SetFloat("_DissolveAmount", dissolve);
            Debug.Log("dfbhsdfjfsdjh");
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
