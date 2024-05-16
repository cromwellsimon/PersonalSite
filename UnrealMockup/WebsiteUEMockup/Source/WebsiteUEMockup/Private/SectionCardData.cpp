// Fill out your copyright notice in the Description page of Project Settings.


#include "SectionCardData.h"

FSectionCardData FSectionCardData::Instantiate(const FString& inSectionTitle, const TArray<FCardData>& inCardData, int32 inSelectedCardIndex)
{
	FSectionCardData sectionCardData;
	sectionCardData.SectionTitle = inSectionTitle;
	sectionCardData.CardData = inCardData;
	sectionCardData.SelectedCardIndex = inSelectedCardIndex;
	return sectionCardData;
}

FSectionCardData USectionCardDataStatics::Instantiate(const FString& inSectionTitle, const TArray<FCardData>& inCardData, int32 inSelectedCardIndex)
{
	return FSectionCardData::Instantiate(inSectionTitle, inCardData, inSelectedCardIndex);
}
