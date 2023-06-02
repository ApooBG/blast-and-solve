using Assets.Scripts;
using Assets.Scripts.bomb_attachment;
using Assets.Scripts.bomb_attachment.Decorators;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class OnImageClick : MonoBehaviour
{
    [SerializeField] Material outlineMaterial;

    [SerializeField] List<Image> listOfExplosionTypes;
    [SerializeField] List<Image> listOfShapes;
    [SerializeField] List<Image> listOfRangeAdjustments;
    [SerializeField] List<Image> listOfSpecialItems;


    public BlockType blockType;
    public Decorator selectedItem;
    public List<Decorator> decoratorList;

    private void Start()
    {
        decoratorList = new List<Decorator>();

        foreach (Image image in listOfExplosionTypes)
        {
            Decorator d = new Decorator(DecoratorTypes.explosion, image, image.transform.localScale);
            decoratorList.Add(d);
        }

        foreach (Image image in listOfShapes)
        {
            Decorator d = new Decorator(DecoratorTypes.shape, image, image.transform.localScale);
            decoratorList.Add(d);
        }

        foreach (Image image in listOfRangeAdjustments)
        {
            Decorator d = new Decorator(DecoratorTypes.range, image, image.transform.localScale);
            decoratorList.Add(d);
        }

        foreach (Image image in listOfSpecialItems)
        {
            Decorator d = new Decorator(DecoratorTypes.special, image, image.transform.localScale);
            decoratorList.Add(d);
        }
    }

    public void ImageClick(Image image)
    {
        /*        switch (image.name)
                {
                    case "Bomb":
                        blockType = BlockType.Bomb;
                        ScaleSelectedItem(image);
                        break;
                    case "Firestarter":
                        ScaleSelectedItem(image);
                        break;
                    case "Line":
                        ScaleSelectedItem(image);
                        break;
                    case "Three-Corridor":
                        ScaleSelectedItem(image);
                        break;
                    case "Circle":
                        ScaleSelectedItem(image);
                        break;
                    case "Star":
                        ScaleSelectedItem(image);
                        break;
                    case "4-way":
                        ScaleSelectedItem(image);
                        break;
                    case "X-Shape":
                        ScaleSelectedItem(image);
                        break;
                    case "Triangle":
                        ScaleSelectedItem(image);
                        break;
                    case "Six-corner":
                        ScaleSelectedItem(image);
                        break;

                    case "fire-explosion":
                        ScaleSelectedItem(image);
                        break;
                    case "ice-explosion":
                        ScaleSelectedItem(image);
                        break;
                    case "sonic-explosion":
                        ScaleSelectedItem(image);
                        break;
                    case "bouncer-explosion":
                        ScaleSelectedItem(image);
                        break;
                    case "detonator-explosion":
                        ScaleSelectedItem(image);
                        break;
                    case "timer-explosion":
                        ScaleSelectedItem(image);
                        break;

                    case "one-explosion-range":
                        ScaleSelectedItem(image);
                        break;
                    case "two-explosion-range":
                        ScaleSelectedItem(image);
                        break;
                    case "one-impact-range":
                        ScaleSelectedItem(image);
                        break;
                    case "two-impact-range":
                        ScaleSelectedItem(image);
                        break;
                }*/
        Decorator item = decoratorList.Find(x => x.image == image);
        if (item  != null)
        {
            ScaleSelectedItem(item);
        }
    }

    void ScaleSelectedItem(Decorator newItem)
    {
        if (selectedItem != null)
        {
            selectedItem.image.transform.localScale = selectedItem.originalScale;
            selectedItem.image.material = null;
            if (newItem == selectedItem)
            {
                selectedItem = null;
                return;
            }

        }
        selectedItem = newItem;
        selectedItem.image.material = outlineMaterial;
        selectedItem.image.transform.SetAsLastSibling();

        if (selectedItem.image.transform.localScale == selectedItem.originalScale)
        {
            ScaleUp(selectedItem.image);
        }
    }

    public void OnPointerEnter(Image newImage)
    {
        if (selectedItem != null)
        {
            if (selectedItem.image != newImage)
                ScaleUp(newImage);
        }

        else
        {
            ScaleUp(newImage);
        }
    }

    public void OnPointerExit(Image newImage)
    {
        if (selectedItem != null)
        {
            if (newImage != selectedItem.image)
            {
                newImage.transform.localScale = decoratorList.Find(x => x.image == newImage).originalScale;
            }
        }

        else
        {
            newImage.transform.localScale = decoratorList.Find(x => x.image == newImage).originalScale;
        }
    }

    void ScaleUp(Image newImage)
    {
        newImage.transform.localScale = new Vector3(newImage.transform.localScale.x * 1.2f, newImage.transform.localScale.y * 1.2f);
        newImage.transform.SetAsLastSibling();

        if (selectedItem != null)
            selectedItem.image.transform.SetAsLastSibling();
    }
}
