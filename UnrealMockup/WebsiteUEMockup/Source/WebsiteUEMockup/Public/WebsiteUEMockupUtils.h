// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "WebsiteUEMockupUtils.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API UWebsiteUEMockupUtils : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintCallable)
	static TArray<struct FSectionCardData> InstantiateSampleData();

	template<typename T>
	static TArray<T> Roulette(const TArray<T>& inArray, int32 inStartingPosition, int32 inBackwardPadding, int32 inForwardPadding);
};

// I know that it's also like this in the C++ STL as well but I am actually not the biggest fan of the fact that manipulation of collections with their respective Algorithms are in-line.
// C++20 has the concept of Views which, to me, work very similarly to IEnumerable<T> in C# where evaluation is lazily done and allows piping from one algorithm to another very simply. I like C++20 Views a lot.
// Also, for templated types, they more-or-less always have to be used in-line. That's part of the reason why they tend to increase compilation times so much in C++
template<typename T>
TArray<T> UWebsiteUEMockupUtils::Roulette(const TArray<T>& inArray, int32 inStartingPosition, int32 inBackwardPadding, int32 inForwardPadding)
{
	// The error message that I get here whenever I put in a function that doesn't actually exist on T, invoke it, then try compiling, is literally just a line of like 10 question marks in a row lol.
	// That's probably the biggest reason why people don't care for templates in C++ too much, C++ in the IDE behaves like a dynamic language whenever in the context of a templated type
	// even if you set up the type constraints above. This may be different in something like CLion or Rider, but just speaking about Visual Studio. Basically, with template types, IntelliSense just turns off.
	// However, this function doesn't even need to access the contents so it doesn't matter.
	// Though, my implementation of this function in the C# version will be a little different since it will use and return an IEnumerable<T> instead of the entire populated array
	TArray<T> newArray;
	int32 arrayLength = inArray.Num();

	TArray<T> backwardPadding;
	int32 backwardIndex = inStartingPosition - 1;
	// Loop around the array in the backward direction to add to the roulette
	while (backwardPadding.Num() < inBackwardPadding)
	{
		if (backwardIndex < 0)
		{
			backwardIndex = arrayLength - 1;
			continue;
		}
		backwardPadding.Add(inArray[backwardIndex]);
		backwardIndex--;
	}

	TArray<T> forwardPadding;
	int32 forwardIndex = inStartingPosition + 1;
	// Loop around the array in the forward direction to add to the roulette
	while (forwardPadding.Num() < inForwardPadding)
	{
		if (forwardIndex >= arrayLength)
		{
			forwardIndex = 0;
			continue;
		}
		forwardPadding.Add(inArray[forwardIndex]);
		forwardIndex++;
	}

	// Then, combine the 3
	Algo::Reverse(backwardPadding);
	newArray.Append(backwardPadding);
	newArray.Add(inArray[inStartingPosition]);
	newArray.Append(forwardPadding);

	return newArray;
}