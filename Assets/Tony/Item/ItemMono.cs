using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ItemMono : MonoBehaviour ,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler{
	
	public Material _originalMaterial;
	public Material _highlightMaterial;

	public void OnPointerClick(PointerEventData eventData){
		OnClick();
	}

	public abstract void OnClick();

	public void OnPointerEnter(PointerEventData eventData){
		OnPointerEnter();
	}

	public virtual void OnPointerEnter(){
	
	}
	
	public void OnPointerExit(PointerEventData eventData){
		OnPointerExit();
	}
	
	public virtual void OnPointerExit(){
	
	}
}
