using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Website.Shared.Cards.Detail;

namespace Website.Shared;

public static class ReflectionStatics
{
	/// <summary>
	/// This may look bizarre but the reason for this is because unlike with virtual methods which redirect the function call at run-time,
	/// method overloads redirect the function call at compile-time.
	/// For instance, if I have a <see cref="List{T}"/> of <see cref="IDetailCard"/> and I try calling my Render static method on it but there is an overload for a <see cref="TextCard"/>,
	/// the version for the <see cref="TextCard"/> will never be called unless if I specifically casted to it because the decision on what function to call is made at compile-time. That's what this function is for.
	/// </summary>
	/// <param name="inStaticType"> The place that your extension methods are held. You probably want to use <see cref="typeof()"/> for this </param>
	/// <param name="inObjectType"> 
	/// The reference to the object that you're wishing to redirect to the specific extension method.
	/// Use <see cref="Object.GetType"/> for this, NOT <see cref="typeof()"/> as this must be the run-time <see cref="Type"/>, not the compile-time <see cref="Type"/>
	/// </param>
	/// <param name="inMethodName"> The name of the extension method </param>
	public static MethodInfo? RedirectExtensionMethod(this Type inStaticType, Type inObjectType, string inMethodName)
	{
		return inStaticType.GetMethods().FirstOrDefault((method) =>
		{
			if (method.Name == inMethodName)
			{
				ParameterInfo? firstParameter = method.GetParameters().FirstOrDefault();
				if (firstParameter != null)
				{
					return firstParameter.ParameterType == inObjectType;
				}
			}
			return false;
		});
	}
}
