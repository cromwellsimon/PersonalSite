// Fill out your copyright notice in the Description page of Project Settings.


#include "CardData.h"

FCardData FCardData::Instantiate(UTexture2D* inTexture, const FString& inTitle, const FString& inSubtitle)
{
	FCardData newCardData;
	newCardData.Texture = inTexture;
	newCardData.Title = inTitle;
	newCardData.Subtitle = inSubtitle;
	return newCardData;
}

FCardData UCardDataStatics::Instantiate(UTexture2D* inTexture, const FString& inTitle, const FString& inSubtitle)
{
	return FCardData::Instantiate(inTexture, inTitle, inSubtitle);
}
