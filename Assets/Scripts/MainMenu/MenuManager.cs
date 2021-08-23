using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public RectTransform loadingImage;
    public RectTransform laylaLogo;

    public List<RectTransform> categories;
    private List<Vector2> categoriesOriginalPos = new List<Vector2>();


    // Start is called before the first frame update
    void Start()
    {
        InitStartConfig();

    }

    private void InitStartConfig()
    {
        laylaLogo.localScale = Vector2.zero;

        for(int i = 0; i< categories.Count;i++)
        {
            categoriesOriginalPos.Add(categories[i].anchoredPosition);
            categories[i].anchoredPosition = Vector2.zero;
            categories[i].localScale = Vector2.zero;
        }


        LoadingImageAnimation();

    }

    private void LoadingImageAnimation()
    {
        loadingImage.DORotate(new Vector3(0f,0f,-500f),3f).OnComplete(()=> loadingImage.DOScale(0f,2f).OnComplete(LaylaLogoAnimation));
        
    }

    private void LaylaLogoAnimation()
    {
        loadingImage.gameObject.SetActive(false);

        laylaLogo.DOScale(1f,3f).OnComplete(CategoriesAnimations);

    }

    private void CategoriesAnimations()
    {
        for (int i = 0; i < categories.Count; i++)
        {
            categories[i].DOScale(1f,3f);
            categories[i].DOAnchorPos(categoriesOriginalPos[i],3f);
            laylaLogo.DOAnchorPos(new Vector2(0,-600), 3f);
        }
    }

    public void GoSelectedLevel(string levelName)
    {
        GameObject tempButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        
        foreach (RectTransform r in categories)
        {
            if (tempButton.name == r.name)
            {
                r.GetComponent<InteractLevelSelect>().enabled = false;

                r.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 5f);
                r.GetComponent<RectTransform>().DOScale(2f, 5f);
                r.GetComponent<RectTransform>().DORotateQuaternion(Quaternion.Euler(0, 270, 0), 5f);
                SceneManager.LoadSceneAsync(levelName);
            }
            else
            {
                r.GetComponent<InteractLevelSelect>().enabled = false;
                r.GetComponent<RectTransform>().DOScale(0, 1f);
            }
                
        }

        
    }




    /* ----------------------------------------------------------------------------
    private void FirstLoading()
    {
        loadingImage.GetComponent<RectTransform>().DORotate(new Vector3(0,0,-500), 5f).OnComplete(ImageScale);
    }

    private void ImageScale()
    {
        laylaLogo.gameObject.SetActive(true);
        for (int i = 0; i < categories.Count; i++)
        {
            categories[i].gameObject.SetActive(true);

            if(i == categories.Count - 1)
                categories[i].DOScale(1f, 10f).OnComplete(ImagePosition);
            else
                categories[i].DOScale(1f, 10f);
        }
    }

    private void ImagePosition()
    {
        for (int i = 0; i < categories.Count; i++)
        {
            if (i == categories.Count - 1)
                categories[i].DOAnchorPos(originalPos[i], 2f).OnComplete(LaylaLogo);
            else
                categories[i].DOAnchorPos(originalPos[i], 2f);  
        }
    }

    private void LaylaLogo()
    {
        laylaLogo.DOScale(1f, 3f);
    }

    // Image  X:-375  Y:-150 Z:-5   
    // Image1 X: 0    Y: 188 Z:-5
    // Image2 X: 375  Y:-150 Z:-5


    //ButtonOnClick
    public void SellectCategory()
    {
        GameObject tempButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        //GameObject tempButton = image1.gameObject;
        foreach(RectTransform r in categories)
        {
            if (tempButton.name == r.name)
                r.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 500), 3f).OnComplete(()=>  OpenTheSelectedScenes(tempButton));
            else
                r.GetComponent<RectTransform>().DOScale(0f,3f).OnComplete(() => r.gameObject.SetActive(false));
        }
    }


    private void OpenTheSelectedScenes(GameObject selectedCategory)
    {
        RectTransform[] tempScenes = selectedCategory.transform.GetChild(2).GetComponentsInChildren<RectTransform>();
        
        for(int i = 0 ; i< tempScenes.Length; i++)
        {
            Vector2 originalPos = tempScenes[i].anchoredPosition;
            tempScenes[i].anchoredPosition = Vector2.zero;
            tempScenes[i].DOScale(1f, 2f);
            tempScenes[i].DOAnchorPos(originalPos,2f);
        }
    }
    */
    // Button OnClick

}
