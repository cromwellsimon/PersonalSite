// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "CardData.h"
#include "CardDataAsset.generated.h"

/**
 * 
 */
UCLASS(BlueprintType)
class WEBSITEUEMOCKUP_API UCardDataAsset : public UDataAsset
{
	GENERATED_BODY()
	
public:
	// Due to lots of issues with fragility that I've had with game engines, I've grown from using EditAnywhere/SerializeField/Export variables everywhere I could to intentionally avoiding them a lot and sticking more to the code.
	// For a bigger project, I think that doing something like this could definitely be problematic (especially whenever refactoring) but for a small mockup project like this, I don't have a problem with it.
	// From least-favorite to most-favorite, my ranking is EditAnywhere -> JSON -> Compile-time.
	// The biggest problem with JSON is the lack of compile-time type safety. You're able to get IDE-time type safety with JSON Schema but if your IDE is set up differently, then you don't get the Schema data at all.
	// The second biggest problem with JSON that invalidates it for a lot of purposes is unserializable data types like references to other assets.
	// This is something that can't really be avoided without setting GUIDs for everything which is how most engines internally deal with things in their own serialization formats,
	// but they typically aren't made to be used by other formats.
	UPROPERTY(EditAnywhere, BlueprintReadWrite)
	UTexture2D* Texture;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
	FString Title;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
	FString Subtitle;

	// I would usually feel inclined to make this contain a lambda as its sole argument so you could pass in any number of changes you would want to make but that would invalidate it from being usable with Blueprint.
	UFUNCTION(BlueprintCallable)
	static UCardDataAsset* Instantiate(UTexture2D* inTexture, const FString& inTitle, const FString& inSubtitle);

	// Blueprint does not support method overloading so this must be called something other than Default unfortunately
	UFUNCTION(BlueprintCallable)
	static UCardDataAsset* Default();
};
