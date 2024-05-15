// Fill out your copyright notice in the Description page of Project Settings.


#include "SectionCardDataAsset.h"
#include <CardDataAsset.h>

USectionCardDataAsset* USectionCardDataAsset::Instantiate(const FString& inSectionTitle, const TArray<class UCardDataAsset*>& inCardData, const int32 inSelectedCardIndex)
{
	auto instance = NewObject<USectionCardDataAsset>();
	instance->SectionTitle = inSectionTitle;
	instance->CardData = inCardData;
	instance->SelectedCardIndex = inSelectedCardIndex;
	return nullptr;
}
