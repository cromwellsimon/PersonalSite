// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "Engine.h"
#include "Engine/DataTable.h"
#include "CardData.generated.h"

USTRUCT(BlueprintType)
// Working purely with structs for simplicity with the Editor.
// I would typically consider making this work with a DataAsset instead but there actually is a side-benefit to doing it this way.
// I can make a function that generates the sample data that I'm looking for and have that exist at compile-time versus a DataAsset that exists in the Content Browser
// that would be open to data loss every time I wanted to refactor something.
// I could do this exact same thing with a UObject or even a DataAsset which isn't instantiated in the Content Browser (but there wouldn't be a point in using a DataAsset over a UObject if you know you're never going to instantiate it),
// but again, for simplicity's sake for the mockup, I'm just going with some simple structs but this would certainly be subject to change in a different project.
struct WEBSITEUEMOCKUP_API FCardData : public FTableRowBase
{
	GENERATED_USTRUCT_BODY()

public:
	// Due to lots of issues with fragility that I've had with game engines, I've grown from using EditAnywhere/SerializeField/Export variables everywhere I could to intentionally avoiding them a lot and sticking more to the code.
	// For a bigger project, I think that doing something like this could definitely be problematic (especially whenever refactoring) but for a small mockup project like this, I don't have a problem with it.
	// From least-favorite to most-favorite, my ranking is EditAnywhere (and equivalents) -> JSON -> Compile-time.
	// The biggest problem with JSON is the lack of compile-time type safety. You're able to get IDE-time type safety with JSON Schema but if your IDE is set up differently, then you don't get the Schema data at all.
	// The second biggest problem with JSON that invalidates it for a lot of purposes is unserializable data types like references to other assets.
	// This is something that can't really be avoided without setting GUIDs for everything which is how most engines internally deal with things in their own serialization formats,
	// but they typically aren't built to be used by other formats.
	UPROPERTY(EditAnywhere, BlueprintReadWrite)
	UTexture2D* Texture;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
	FString Title;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
	FString Subtitle;

	FCardData(){}

	static FCardData Instantiate(UTexture2D* inTexture, const FString& inTitle, const FString& inSubtitle);
};

UCLASS()
// In Unreal Engine types, the static functions do typically exist on the type itself (like all of the FString:: functions)
// and then the Kismet (shoutout to UDK/UE3, I loved using UDK) library just redirect the Blueprint function calls to those static functions.
class WEBSITEUEMOCKUP_API UCardDataStatics : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintCallable)
	static FCardData Instantiate(UTexture2D* inTexture, const FString& inTitle, const FString& inSubtitle);
};
