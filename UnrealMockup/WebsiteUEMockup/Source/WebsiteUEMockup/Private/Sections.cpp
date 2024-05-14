// Fill out your copyright notice in the Description page of Project Settings.


#include "Sections.h"
#include "Components/VerticalBox.h"
#include "Components/VerticalBoxSlot.h"
#include <SectionText.h>

void USections::ConstructSections(const TArray<FString>& inSections)
{
	_VerticalBoxRef->ClearChildren();

	TArray<USectionText*> children;

	for (int i = 0; i < inSections.Num(); i++)
	{
		USectionText* child = Cast<USectionText>(CreateWidget(this, _SectionTextClass));
		_VerticalBoxRef->AddChildToVerticalBox(child);
		child->Constructor(inSections[i]);
		children.Add(child);
		child->SetSize(TextSize);
	}

	TArray<UWidget*> verticalBoxChildren = _VerticalBoxRef->GetAllChildren();
	for (int i = verticalBoxChildren.Num() - 2; i >= 0; i--)
	{
		USectionText* previousChild = Cast<USectionText>(children[i + 1]);
		USectionText* currentChild = Cast<USectionText>(children[i]);
		currentChild->SetRenderOpacity(previousChild->GetRenderOpacity() - 0.2);
		currentChild->SetSize(previousChild->GetSize() - 2);
	}

}

void USections::Init(UVerticalBox* inVerticalBoxRef, TSubclassOf<USectionText> inSectionTextClass)
{
	_VerticalBoxRef = inVerticalBoxRef;
	_SectionTextClass = inSectionTextClass;
}

void USections::Constructor(const TArray<FString>& inSections, const FString& inActiveSection, const float& inVerticalPadding)
{
	if (_SectionTextClass != nullptr)
	{
		UE_LOG(LogTemp, Warning, TEXT("%d"), GetSectionsToDisplay(inSections, inActiveSection).Num());
		ConstructSections(GetSectionsToDisplay(inSections, inActiveSection));
		SetMargin(inVerticalPadding);
	}
}

TArray<FString> USections::GetSectionsToDisplay(const TArray<FString>& inSections, const FString& inActiveSection)
{
	int32 indexOfActiveSection;
	bool result = inSections.Find(inActiveSection, indexOfActiveSection);
	TArray<FString> sectionsToDisplay;
	if (result == false)
	{
		return sectionsToDisplay;
	}
	int32 index = indexOfActiveSection;
	while (sectionsToDisplay.Num() < 5)
	{
		if (index < 0)
		{
			index = inSections.Num() - 1;
			continue;
		}
		sectionsToDisplay.Add(inSections[index]);
		index--;
	}
	Algo::Reverse(sectionsToDisplay);
	return sectionsToDisplay;
}

void USections::SetMargin(const float& inVerticalPadding)
{
	_VerticalPadding = inVerticalPadding;
	for (UWidget* child : _VerticalBoxRef->GetAllChildren())
	{
		UVerticalBoxSlot* slot = Cast<UVerticalBoxSlot>(child->Slot);
		slot->SetPadding(FMargin(0, 0, 0, _VerticalPadding));
	}
}
