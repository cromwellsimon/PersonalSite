// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "CardData.h"
#include "Card.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API UCard : public UUserWidget
{
	GENERATED_BODY()
	
private:
	UPROPERTY()
	FCardData _CardData;

	UPROPERTY()
	class UTextBlock* _TitleTextBlockRef;

	UPROPERTY()
	class UTextBlock* _SubtitleTextBlockRef;

	UPROPERTY()
	class UImage* _ImageRef;

protected:
	UFUNCTION(BlueprintCallable)
	void Init(class UTextBlock* inTitleTextBlockRef, class UTextBlock* inSubtitleTextBlockRef, class UImage* inImageRef);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const FCardData& inCardData);

	UFUNCTION(BlueprintCallable)
	void SetTitle(const FString& inTitle);

	UFUNCTION(BlueprintCallable)
	const FString& GetTitle();

	UFUNCTION(BlueprintCallable)
	void SetSubtitle(const FString& inSubtitle);

	UFUNCTION(BlueprintCallable)
	void SetTexture(UTexture2D* inTexture);
};
