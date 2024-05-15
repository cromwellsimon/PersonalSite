// Fill out your copyright notice in the Description page of Project Settings.


#include "WebsiteUEMockupUtils.h"
#include <SectionCardDataAsset.h>
#include <CardDataAsset.h>

TArray<USectionCardDataAsset*> UWebsiteUEMockupUtils::InstantiateSampleData()
{
	TArray<USectionCardDataAsset*> data;

	TArray<UCardDataAsset*> section1cards;
	section1cards.Add(UCardDataAsset::Instantiate(nullptr, TEXT("Section 1, Card 1"), TEXT("")));
	section1cards.Add(UCardDataAsset::Instantiate(nullptr, TEXT("Section 1, Card 2"), TEXT("")));
	data.Add(USectionCardDataAsset::Instantiate(TEXT("Section 1"), section1cards, 1));

	TArray<UCardDataAsset*> section2cards;
	section2cards.Add(UCardDataAsset::Instantiate(nullptr, TEXT("Section 2, Card 1"), TEXT("")));
	data.Add(USectionCardDataAsset::Instantiate(TEXT("Section 2"), section2cards, 1));

	TArray<UCardDataAsset*> section3cards;
	section3cards.Add(UCardDataAsset::Instantiate(nullptr, TEXT("Section 3, Card 1"), TEXT("")));
	section3cards.Add(UCardDataAsset::Instantiate(nullptr, TEXT("Section 3, Card 2"), TEXT("")));
	section3cards.Add(UCardDataAsset::Instantiate(nullptr, TEXT("Section 3, Card 3"), TEXT("")));
	data.Add(USectionCardDataAsset::Instantiate(TEXT("Section 3"), section3cards, 2));

	return data;
}
