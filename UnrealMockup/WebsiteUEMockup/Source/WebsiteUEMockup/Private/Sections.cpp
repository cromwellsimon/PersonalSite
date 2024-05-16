// Fill out your copyright notice in the Description page of Project Settings.


#include "Sections.h"
#include "Components/VerticalBox.h"
#include "Components/VerticalBoxSlot.h"
#include <SectionText.h>
#include "WebsiteUEMockupUtils.h"

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
		ConstructSections(UWebsiteUEMockupUtils::Roulette(inSections, inSections.IndexOfByKey(inActiveSection), 4, 0));
		SetMargin(inVerticalPadding);
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
