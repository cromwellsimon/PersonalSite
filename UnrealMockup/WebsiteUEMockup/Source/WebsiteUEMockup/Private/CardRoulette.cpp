// Fill out your copyright notice in the Description page of Project Settings.


#include "CardRoulette.h"
#include "Components/CanvasPanel.h"
#include "Components/CanvasPanelSlot.h"
#include "Components/TextBlock.h"
#include <Card.h>

void UCardRoulette::Init(UCanvasPanel* inCanvasPanelRef, UTextBlock* inCountTextRef, TSubclassOf<UCard> inCardWidgetType)
{
	_CanvasPanelRef = inCanvasPanelRef;
	_CountTextRef = inCountTextRef;
	_CardWidgetType = inCardWidgetType;
}

void UCardRoulette::SetCardData(const TArray<FCardData>& inCardData)
{
	_CardData = inCardData;
	_CanvasPanelRef->ClearChildren();
	for (FCardData cardData : _CardData)
	{
		UCard* newCard = Cast<UCard>(CreateWidget(this, _CardWidgetType));
		UCanvasPanelSlot* canvasPanelSlot = Cast<UCanvasPanelSlot>(_CanvasPanelRef->AddChild(newCard));
		canvasPanelSlot->SetAnchors(FAnchors(0, 0.5, 0, 0.5));
		canvasPanelSlot->SetAlignment(FVector2D(0, 0.5));
		newCard->Constructor(cardData);
	}
}

const UCard* UCardRoulette::GetSelectedCard()
{
	return SelectedCard;
}

void UCardRoulette::SetSelectedCard(int32 inSelectedCardIndex)
{
	SelectedCard = Cast<UCard>(_CanvasPanelRef->GetChildAt(inSelectedCardIndex - 1));
	if (SelectedCard == nullptr)
	{
		SetSelectedCard(1);
		return;
	}
	TArray<UWidget*> children = _CanvasPanelRef->GetAllChildren();
	TArray<UCanvasPanelSlot*> slots;
	for (UWidget* child : children)
	{
		slots.Add(Cast<UCanvasPanelSlot>(child->Slot));
	}
	int32 indexOfSelectedCard;
	bool result = children.Find(SelectedCard, indexOfSelectedCard);
	if (result == false)
	{
		return;
	}
	for (int32 index = children.Num() - 1; index >= 0; index--)
	{
		children[index]->SetRenderScale(FVector2D(1));
		slots[index]->SetSize(CardSize);
		slots[index]->SetPosition(SelectedCardPosition);
		slots[index]->SetZOrder(-index);
	}
	FVector2D selectedCardSize = slots[indexOfSelectedCard]->GetSize();
	// For everything before the SelectedCard...
	for (int32 index = indexOfSelectedCard - 1; index >= 0; index--)
	{
		int32 indexDelta = indexOfSelectedCard - index;
		double scale = 1 + (indexDelta * 0.1);
		children[index]->SetRenderScale(FVector2D(scale));
		UCanvasPanelSlot* previousCard = slots[index + 1];
		double xPosition = previousCard->GetPosition().X - (selectedCardSize.X * (scale * 1.25));
		slots[index]->SetPosition(FVector2D(xPosition, SelectedCardPosition.Y));
	}
	// For everything after the SelectedCard...
	for (int32 index = indexOfSelectedCard + 1; index < children.Num(); index++)
	{
		int32 indexDelta = index - indexOfSelectedCard;
		double renderScale = FMath::Clamp(1 - (indexDelta * 0.1), 0, 1);
		double xPositionScale = FMath::Clamp(1 - (indexDelta * 0.09), 0, 1);
		children[index]->SetRenderScale(FVector2D(renderScale));
		double xPosition;
		// Past 6 elements, the cards will start going in the reverse direction because of the scale.
		// So, before 6 elements, set the position multiplicatively, but afterwards, do it linearly
		if (indexDelta < 6)
		{
			xPosition = slots[index]->GetPosition().X + (selectedCardSize.X * (indexDelta * (xPositionScale)));
		}
		else
		{
			UCanvasPanelSlot* previousCard = slots[index - 1];
			xPosition = previousCard->GetPosition().X + (selectedCardSize.X * 0.1);
		}
		slots[index]->SetPosition(FVector2D(xPosition, SelectedCardPosition.Y));
	}

	SetCountText(indexOfSelectedCard, children.Num());
}

void UCardRoulette::SetCountText(const int32& inSelectedIndex, const int32& inTotalNum)
{
	FString formattedString = FString::Format(TEXT("{0} of {1}"), { FString::FromInt(inSelectedIndex + 1), FString::FromInt(inTotalNum) });
	_CountTextRef->SetText(FText::FromString(*formattedString));
}

void UCardRoulette::Constructor(const TArray<FCardData>& inCardData, int32 inSelectedCardIndex)
{
	SetCardData(inCardData);
	SetSelectedCard(inSelectedCardIndex);
}

void UCardRoulette::Test()
{
	for (UWidget* child : _CanvasPanelRef->GetAllChildren())
	{
		UCanvasPanelSlot* slot = Cast<UCanvasPanelSlot>(child->Slot);
		UE_LOG(LogTemp, Warning, TEXT("Anchor == %f %f %f %f"), slot->GetAnchors().Minimum.X, slot->GetAnchors().Minimum.Y, slot->GetAnchors().Maximum.X, slot->GetAnchors().Maximum.Y);
	}
}
