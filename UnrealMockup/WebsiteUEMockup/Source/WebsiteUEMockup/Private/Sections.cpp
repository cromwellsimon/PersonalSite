// Fill out your copyright notice in the Description page of Project Settings.


#include "Sections.h"
#include "Components/VerticalBox.h"
#include "Components/VerticalBoxSlot.h"
#include <SectionText.h>

void USections::Init(UVerticalBox* inVerticalBoxRef, TSubclassOf<UUserWidget> inSectionTextClass)
{
	VerticalBoxRef = inVerticalBoxRef;
	SectionTextClass = inSectionTextClass;
}

void USections::Constructor(const TArray<FText>& inSections, const FText& inActiveSection, const float& inVerticalPadding)
{
	if (SectionTextClass != nullptr)
	{
		SetSections(inSections);
		SetActiveSection(inActiveSection);
		SetMargin(inVerticalPadding);
	}
}

void USections::SetSections(const TArray<FText>& inSections)
{
	_Sections = inSections;
	VerticalBoxRef->ClearChildren();
	for (FText text : _Sections)
	{
		UUserWidget* widget = CreateWidget(this, SectionTextClass);
		VerticalBoxRef->AddChildToVerticalBox(widget);
		USectionText* sectionText = Cast<USectionText>(widget);
		sectionText->Constructor(text);
	}
}

void USections::SetActiveSection(const FText& inActiveSection)
{
	TArray<USectionText*> children;
	for (UWidget* child : VerticalBoxRef->GetAllChildren())
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
	int32 index = _Sections.IndexOfByPredicate([&](const FText& element)
		{
			return element.EqualTo(_ActiveSection);
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
	for (UWidget* child : VerticalBoxRef->GetAllChildren())
	{
		UVerticalBoxSlot* slot = Cast<UVerticalBoxSlot>(child->Slot);
		slot->SetPadding(FMargin(0, 0, 0, _VerticalPadding));
	}
}
