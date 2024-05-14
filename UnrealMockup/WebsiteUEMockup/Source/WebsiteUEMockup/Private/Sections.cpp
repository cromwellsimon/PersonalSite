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
		//SetSections(inSections);
		//SetActiveSection(inActiveSection);
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

void USections::SetSections(const TArray<FString>& inSections)
{
	_Sections = inSections;
	_VerticalBoxRef->ClearChildren();
	for (FString text : _Sections)
	{
		UUserWidget* widget = CreateWidget(this, _SectionTextClass);
		_VerticalBoxRef->AddChildToVerticalBox(widget);
		USectionText* sectionText = Cast<USectionText>(widget);
		sectionText->Constructor(text);
	}
}

void USections::SetActiveSection(const FString& inActiveSection)
{
	TArray<USectionText*> children;
	for (UWidget* child : _VerticalBoxRef->GetAllChildren())
	{
		children.Add(Cast<USectionText>(child));
	}
	for (USectionText* child : children)
	{
		child->SetRenderOpacity(1);
		child->SetSize(TextSize);
	}

	_ActiveSection = inActiveSection;
	// I guess FText doesn't override the equality operator? I'm not able to just do a Contains here
	int32 index = _Sections.IndexOfByPredicate([&](const FString& element)
		{
			return element.Equals(_ActiveSection);
		});

	if (index != INDEX_NONE)
	{
		// For everything before, reduce the opacity and scale until it's 0
		for (int i = index - 1; i >= 0; i--)
		{
			USectionText* previousChild = children[i + 1];
			USectionText* currentChild = children[i];
			currentChild->SetRenderOpacity(previousChild->GetRenderOpacity() - 0.2);
			currentChild->SetSize(previousChild->GetSize() - 2);
		}
		// For everything past the active section, make it invisible
		for (int i = index + 1; i < _Sections.Num(); i++)
		{
			children[i]->SetRenderOpacity(0);
		}
	}
	else if (_Sections.Num() > 0)
	{
		SetActiveSection(_Sections[_Sections.Num() - 1]);
	}
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
