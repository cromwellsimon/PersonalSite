// Fill out your copyright notice in the Description page of Project Settings.


#include "Dashboard.h"
#include <Sections.h>
#include <CardRoulette.h>

void UDashboard::Init(UCardRoulette* inCardRoulette, USections* inSections)
{
	_CardRoulette = inCardRoulette;
	_Sections = inSections;
}

void UDashboard::Constructor(const TArray<FSectionCardData>& inSectionCardData, const FString& inActiveSection)
{
	_SectionCardData = inSectionCardData;
	_ActiveSection = inActiveSection;

	TArray<FString> sections;
	bool activeSectionCardDataFound = false;
	// Tried doing this with just a pointer but I sometimes got access violation exceptions even though I was checking for a nullptr...
	// I wonder if Unreal Engine macros prohibits pointers to structs? I wouldn't imagine that'd be the case, but I don't know why I'd be having issues with it.
	// Other times, I got random CJK characters sometimes in the text lol
	FSectionCardData activeSectionCardData;
	for (FSectionCardData sectionCardData : _SectionCardData)
	{
		sections.Add(sectionCardData.SectionTitle);
		if (sectionCardData.SectionTitle.Equals(_ActiveSection))
		{
			activeSectionCardData = sectionCardData;
			activeSectionCardDataFound = true;
		}
	}
	_Sections->Constructor(sections, _ActiveSection, 15);

	if (activeSectionCardDataFound != false)
	{
		_CardRoulette->Constructor(activeSectionCardData.CardData, activeSectionCardData.SelectedCardIndex);
	}
}

const int32 UDashboard::GetActiveSectionIndex()
{
	return _SectionCardData.IndexOfByPredicate([&](FSectionCardData element)
		{
			return element.SectionTitle == _ActiveSection;
		});
}

void UDashboard::MoveSection(bool upwards)
{
	int32 activeSectionIndex = GetActiveSectionIndex();
	if (upwards)
	{
		activeSectionIndex -= 1;
		if (activeSectionIndex < 0)
		{
			activeSectionIndex = _SectionCardData.Num() - 1;
		}
	}
	else
	{
		activeSectionIndex += 1;
		if (activeSectionIndex >= _SectionCardData.Num())
		{
			activeSectionIndex = 0;
		}
	}

	Constructor(_SectionCardData, _SectionCardData[activeSectionIndex].SectionTitle);
}

void UDashboard::MoveCard(bool rightwards)
{
	int32 activeSectionIndex = GetActiveSectionIndex();
	FSectionCardData sectionCardData = _SectionCardData[activeSectionIndex];
	int32 activeCardIndex = sectionCardData.SelectedCardIndex;
	if (rightwards)
	{
		activeCardIndex += 1;
		if (activeCardIndex >= sectionCardData.CardData.Num() + 1)
		{
			sectionCardData.SelectedCardIndex = 1;
		}
		else
		{
			sectionCardData.SelectedCardIndex = activeCardIndex;
		}
	}
	else
	{
		activeCardIndex -= 1;
		if (activeCardIndex < 1)
		{
			sectionCardData.SelectedCardIndex = sectionCardData.CardData.Num();
		}
		else
		{
			sectionCardData.SelectedCardIndex = activeCardIndex;
		}
	}

	Constructor(_SectionCardData, sectionCardData.SectionTitle);
}
