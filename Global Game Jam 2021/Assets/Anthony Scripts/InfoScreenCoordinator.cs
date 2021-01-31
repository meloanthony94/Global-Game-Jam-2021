using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreenCoordinator : MonoBehaviour
{
    [SerializeField]
    private Image leftInfoImage;
    [SerializeField]
    private Image rightInfoImage;

    [SerializeField]
    private List<Sprite> leftInfoImages = new List<Sprite>();
    [SerializeField]
    private List<Sprite> rightInfoImages = new List<Sprite>();

    private int imageIndex = 0;

    public void HandleLeftButtonPress()
    {
        imageIndex--;

        if (imageIndex < 0)
        {
            imageIndex = leftInfoImages.Count - 1;
        }

        UpdateSpriteImage(imageIndex);
    }

    public void HandleRightButtonPress()
    {
        imageIndex++;

        if (imageIndex >= leftInfoImages.Count)
        {
            imageIndex = 0;
        }

        UpdateSpriteImage(imageIndex);
    }

    private void UpdateSpriteImage(int imageIndex)
    {
        if (imageIndex >= rightInfoImages.Count)
        {
            rightInfoImage.enabled = false;
        }
        else
        {
            rightInfoImage.enabled = true;
            rightInfoImage.sprite = rightInfoImages[imageIndex];
        }

        leftInfoImage.sprite = leftInfoImages[imageIndex];
    }
}
