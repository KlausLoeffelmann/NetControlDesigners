﻿' -------------------------------------------------------------------
' Copyright (c) Microsoft Corporation. All Rights Reserved.
' -------------------------------------------------------------------
' Copied from https://github/dotnet/runtime
' Note: These attributes were introduced in .NET Core 3.0 and .NET 5.

Namespace Global.System.Diagnostics.CodeAnalysis

#If Not NETCOREAPP3_0_OR_GREATER Then

    ''' <summary>Specifies that null is allowed as an input even if the corresponding type disallows it.</summary>
    <AttributeUsage(AttributeTargets.Field Or AttributeTargets.Parameter Or AttributeTargets.Property, Inherited:=False)>
    Friend NotInheritable Class AllowNullAttribute
        Inherits Attribute

    End Class

    ''' <summary>Specifies that null is disallowed as an input even if the corresponding type allows it.</summary>
    <AttributeUsage(AttributeTargets.Field Or AttributeTargets.Parameter Or AttributeTargets.Property, Inherited:=False)>
    Friend NotInheritable Class DisallowNullAttribute
        Inherits Attribute

    End Class

    ''' <summary>Specifies that an output may be null even if the corresponding type disallows it.</summary>
    <AttributeUsage(AttributeTargets.Field Or AttributeTargets.Parameter Or AttributeTargets.Property Or AttributeTargets.ReturnValue, Inherited:=False)>
    Friend NotInheritable Class MaybeNullAttribute
        Inherits Attribute

    End Class

    ''' <summary>Specifies that an output will not be null even if the corresponding type allows it. Specifies that an input argument was not null when the call returns.</summary>
    <AttributeUsage(AttributeTargets.Field Or AttributeTargets.Parameter Or AttributeTargets.Property Or AttributeTargets.ReturnValue, Inherited:=False)>
    Friend NotInheritable Class NotNullAttribute
        Inherits Attribute

    End Class

    ''' <summary>Specifies that when a method returns <see cref="ReturnValue"/>, the parameter may be null even if the corresponding type disallows it.</summary>
    <AttributeUsage(AttributeTargets.Parameter, Inherited:=False)>
    Friend NotInheritable Class MaybeNullWhenAttribute
        Inherits Attribute

        ''' <summary>Initializes the attribute with the specified return value condition.</summary>
        ''' <param name="returnValue">
        ''' The return value condition. If the method returns this value, the associated parameter may be null.
        ''' </param>
        Public Sub New(ByVal returnValue As Boolean)
            Me.ReturnValue = returnValue
        End Sub

        ''' <summary>Gets the return value condition.</summary>
        Public ReadOnly Property ReturnValue() As Boolean
    End Class

    ''' <summary>Specifies that when a method returns <see cref="ReturnValue"/>, the parameter will not be null even if the corresponding type allows it.</summary>
    <AttributeUsage(AttributeTargets.Parameter, Inherited:=False)>
    Friend NotInheritable Class NotNullWhenAttribute
        Inherits Attribute

        ''' <summary>Initializes the attribute with the specified return value condition.</summary>
        ''' <param name="returnValue">
        ''' The return value condition. If the method returns this value, the associated parameter will not be null.
        ''' </param>
        Public Sub New(ByVal returnValue As Boolean)
            Me.ReturnValue = returnValue
        End Sub

        ''' <summary>Gets the return value condition.</summary>
        Public ReadOnly Property ReturnValue() As Boolean
    End Class

    ''' <summary>Specifies that the output will be non-null if the named parameter is non-null.</summary>
    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Property Or AttributeTargets.ReturnValue, AllowMultiple:=True, Inherited:=False)>
    Friend NotInheritable Class NotNullIfNotNullAttribute
        Inherits Attribute

        ''' <summary>Initializes the attribute with the associated parameter name.</summary>
        ''' <param name="parameterName">
        ''' The associated parameter name.  The output will be non-null if the argument to the parameter specified is non-null.
        ''' </param>
        Public Sub New(ByVal parameterName As String)
            Me.ParameterName = parameterName
        End Sub

        ''' <summary>Gets the associated parameter name.</summary>
        Public ReadOnly Property ParameterName() As String
    End Class

    ''' <summary>Applied to a method that will never return under any circumstance.</summary>
    <AttributeUsage(AttributeTargets.Method, Inherited:=False)>
    Friend NotInheritable Class DoesNotReturnAttribute
        Inherits Attribute

    End Class

    ''' <summary>Specifies that the method will not return if the associated Boolean parameter is passed the specified value.</summary>
    <AttributeUsage(AttributeTargets.Parameter, Inherited:=False)>
    Friend NotInheritable Class DoesNotReturnIfAttribute
        Inherits Attribute

        ''' <summary>Initializes the attribute with the specified parameter value.</summary>
        ''' <param name="parameterValue">
        ''' The condition parameter value. Code after the method will be considered unreachable by diagnostics if the argument to
        ''' the associated parameter matches this value.
        ''' </param>
        Public Sub New(ByVal parameterValue As Boolean)
            Me.ParameterValue = parameterValue
        End Sub

        ''' <summary>Gets the condition parameter value.</summary>
        Public ReadOnly Property ParameterValue() As Boolean
    End Class

#End If

#If Not NET5_0_OR_GREATER Then

    ''' <summary>Specifies that the method or property will ensure that the listed field and property members have not-null values.</summary>
    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Property, Inherited:=False, AllowMultiple:=True)>
    Friend NotInheritable Class MemberNotNullAttribute
        Inherits Attribute

        ''' <summary>Initializes the attribute with a field or property member.</summary>
        ''' <param name="member">
        ''' The field or property member that is promised to be not-null.
        ''' </param>
        Public Sub New(ByVal member As String)
            Members = {member}
        End Sub

        ''' <summary>Initializes the attribute with the list of field and property members.</summary>
        ''' <param name="members">
        ''' The list of field and property members that are promised to be not-null.
        ''' </param>
        Public Sub New(ParamArray ByVal members() As String)
            Me.Members = members
        End Sub

        ''' <summary>Gets field or property member names.</summary>
        Public ReadOnly Property Members() As String()
    End Class

    ''' <summary>Specifies that the method or property will ensure that the listed field and property members have not-null values when returning with the specified return value condition.</summary>
    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Property, Inherited:=False, AllowMultiple:=True)>
    Friend NotInheritable Class MemberNotNullWhenAttribute
        Inherits Attribute

        ''' <summary>Initializes the attribute with the specified return value condition and a field or property member.</summary>
        ''' <param name="returnValue">
        ''' The return value condition. If the method returns this value, the associated parameter will not be null.
        ''' </param>
        ''' <param name="member">
        ''' The field or property member that is promised to be not-null.
        ''' </param>
        Public Sub New(ByVal returnValue As Boolean, ByVal member As String)
            Me.ReturnValue = returnValue
            Members = {member}
        End Sub

        ''' <summary>Initializes the attribute with the specified return value condition and list of field and property members.</summary>
        ''' <param name="returnValue">
        ''' The return value condition. If the method returns this value, the associated parameter will not be null.
        ''' </param>
        ''' <param name="members">
        ''' The list of field and property members that are promised to be not-null.
        ''' </param>
        Public Sub New(ByVal returnValue As Boolean, ParamArray ByVal members() As String)
            Me.ReturnValue = returnValue
            Me.Members = members
        End Sub

        ''' <summary>Gets the return value condition.</summary>
        Public ReadOnly Property ReturnValue() As Boolean

        ''' <summary>Gets field or property member names.</summary>
        Public ReadOnly Property Members() As String()
    End Class

#End If

End Namespace
