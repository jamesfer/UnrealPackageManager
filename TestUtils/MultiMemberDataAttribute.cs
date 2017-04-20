using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnrealPackageManager.TestUtils
{
	[Xunit.Sdk.DataDiscoverer("Xunit.Sdk.DataDiscoverer", "xunit.core")]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	class MultiMemberDataAttribute : Xunit.Sdk.DataAttribute
	{
		readonly object expectedValue;
		readonly object actualValue;

		public MultiMemberDataAttribute(object expected, object actual)
		{
			expectedValue = expected;
			actualValue = actual;
		}

		override public IEnumerable<object[]> GetData(MethodInfo testMethod)
		{
			IEnumerable<object> expectedItems = null;
			IEnumerable<object> actualItems = null;

			// Attempt to parse each of the values as a method name first.
			string expectedMemberName = expectedValue as string;
			string actualMemberName = actualValue as string;
			if (expectedMemberName != null && actualMemberName != null)
			{
				expectedItems = GetMemberValue(expectedMemberName, testMethod);
				actualItems = GetMemberValue(actualMemberName, testMethod);
			}
			// Otherwise treat them as object arrays
			else
			{
				expectedItems = expectedValue as object[];
				actualItems = actualValue as object[];
			}

			if (expectedItems != null && actualItems != null)
			{
				// Zip the two object arrays together and return them.
				return expectedItems.Zip(actualItems, (a, b) => new object[] { a, b });
			}
			else
			{
				throw new ArgumentException("Expected and actual values were not of the correct types. Should have been either an array of a name of a member.");
			}
		}

		IEnumerable<object> GetMemberValue(string memberName, MethodInfo testMethod)
		{
			var type = /* MemberType ?? */ testMethod.DeclaringType;
			var accessor = GetPropertyAccessor(type, memberName) ?? GetFieldAccessor(type, memberName) /* ?? GetMethodAccessor(type, memberName) */;
			if (accessor == null)
			{
				//var parameterText = Parameters?.Length > 0 ? $" with parameter types: {string.Join(", ", Parameters.Select(p => p?.GetType().FullName ?? "(null)"))}" : "";
				var parameterText = "";
				throw new ArgumentException($"Could not find public static member (property, field, or method) named '{memberName}' on {type.FullName}{parameterText}");
			}

			var obj = accessor();
			if (obj == null)
				return null;

			var dataItems = obj as IEnumerable<object>;
			if (dataItems == null)
				throw new ArgumentException($"Property {memberName} on {type.FullName} did not return IEnumerable<object>");

			return dataItems;
		}

		Func<object> GetFieldAccessor(Type type, string memberName)
		{
			FieldInfo fieldInfo = null;
			for (var reflectionType = type; reflectionType != null; reflectionType = reflectionType.GetTypeInfo().BaseType)
			{
				fieldInfo = reflectionType.GetRuntimeField(memberName);
				if (fieldInfo != null)
					break;
			}

			if (fieldInfo == null || !fieldInfo.IsStatic)
				return null;

			return () => fieldInfo.GetValue(null);
		}

		//Func<object> GetMethodAccessor(Type type, string memberName)
		//{
		//	MethodInfo methodInfo = null;
		//	var parameterTypes = Parameters == null ? new Type[0] : Parameters.Select(p => p?.GetType()).ToArray();
		//	for (var reflectionType = type; reflectionType != null; reflectionType = reflectionType.GetTypeInfo().BaseType)
		//	{
		//		methodInfo = reflectionType.GetRuntimeMethods()
		//								   .FirstOrDefault(m => m.Name == memberName && ParameterTypesCompatible(m.GetParameters(), parameterTypes));
		//		if (methodInfo != null)
		//			break;
		//	}

		//	if (methodInfo == null || !methodInfo.IsStatic)
		//		return null;

		//	return () => methodInfo.Invoke(null, Parameters);
		//}

		Func<object> GetPropertyAccessor(Type type, string memberName)
		{
			PropertyInfo propInfo = null;
			for (var reflectionType = type; reflectionType != null; reflectionType = reflectionType.GetTypeInfo().BaseType)
			{
				propInfo = reflectionType.GetRuntimeProperty(memberName);
				if (propInfo != null)
					break;
			}

			if (propInfo == null || propInfo.GetMethod == null || !propInfo.GetMethod.IsStatic)
				return null;

			return () => propInfo.GetValue(null, null);
		}

		//static bool ParameterTypesCompatible(ParameterInfo[] parameters, Type[] parameterTypes)
		//{
		//	if (parameters?.Length != parameterTypes.Length)
		//		return false;

		//	for (int idx = 0; idx < parameters.Length; ++idx)
		//		if (parameterTypes[idx] != null && !parameters[idx].ParameterType.GetTypeInfo().IsAssignableFrom(parameterTypes[idx].GetTypeInfo()))
		//			return false;

		//	return true;
		//}
	}
}
