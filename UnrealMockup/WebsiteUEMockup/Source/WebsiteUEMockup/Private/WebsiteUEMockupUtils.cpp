// Fill out your copyright notice in the Description page of Project Settings.


#include "WebsiteUEMockupUtils.h"
#include <CardData.h>
#include <SectionCardData.h>

// This is what I mean whenever saying that I prefer making my data compile-time.
// Changing the constructor function in any way and re-compiling causes errors which won't allow the game to start until all but doesn't result in any data loss.
// I would prefer to be able to use the actual constructor because the syntax is a lot nicer-looking (it looks almost exactly like JSON) but this works as well
TArray<FSectionCardData> UWebsiteUEMockupUtils::InstantiateSampleData()
{
	return TArray<FSectionCardData> { 
		FSectionCardData::Instantiate(TEXT("Section 1"), TArray<FCardData> {
			FCardData::Instantiate(nullptr, TEXT("Section 1, Card 1"), TEXT("")),
			FCardData::Instantiate(nullptr, TEXT("Section 1, Card 2"), TEXT("")),
		}),
		FSectionCardData::Instantiate(TEXT("Section 2"), TArray<FCardData> {
			FCardData::Instantiate(nullptr, TEXT("Section 2, Card 1"), TEXT("")),
		}),
		FSectionCardData::Instantiate(TEXT("Section 3"), TArray<FCardData> {
			FCardData::Instantiate(nullptr, TEXT("Section 3, Card 1"), TEXT("")),
			FCardData::Instantiate(nullptr, TEXT("Section 3, Card 2"), TEXT("")),
			FCardData::Instantiate(nullptr, TEXT("Section 3, Card 3"), TEXT("")),
		})
	};
}
