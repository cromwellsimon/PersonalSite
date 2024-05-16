// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "CardData.h"
#include "CardRoulette.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API UCardRoulette : public UUserWidget
{
	GENERATED_BODY()
	
private:
	UPROPERTY()
	class UCanvasPanel* _CanvasPanelRef;

	UPROPERTY()
	class UTextBlock* _CountTextRef;

	UPROPERTY()
	TArray<FCardData> _CardData;

	UPROPERTY()
	TSubclassOf<UUserWidget> _CardWidgetType;

	UFUNCTION()
	void SetCountText(const int32& inSelectedIndex, const int32& inTotalNum);

protected:
	UFUNCTION(BlueprintCallable)
	void Init(class UCanvasPanel* inCanvasPanelRef, class UTextBlock* inCountTextRef, TSubclassOf<class UCard> inCardWidgetType);

	UPROPERTY(BlueprintReadWrite)
	class UCard* SelectedCard;

public:
	UPROPERTY(BlueprintReadWrite)
	FVector2D SelectedCardPosition = FVector2D(0, 0);

	UPROPERTY(BlueprintReadWrite)
	FVector2D CardSize = FVector2D(500, 400);

	UFUNCTION(BlueprintCallable)
	void SetCardData(const TArray<FCardData>& inCardData);

	UFUNCTION(BlueprintCallable)
	const class UCard* GetSelectedCard();

	UFUNCTION(BlueprintCallable)
	void SetSelectedCard(int32 inSelectedCardIndex);

	UFUNCTION(BlueprintCallable)
	void Constructor(const TArray<FCardData>& inCardData, int32 inSelectedCardIndex);
};
