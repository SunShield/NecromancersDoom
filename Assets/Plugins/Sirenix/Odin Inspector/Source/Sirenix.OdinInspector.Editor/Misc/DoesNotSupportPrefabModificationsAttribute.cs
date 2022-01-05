//-----------------------------------------------------------------------
// <copyright file="DoesNotSupportPrefabModificationsAttribute.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#if UNITY_EDITOR
namespace Sirenix.OdinInspector.Editor
{
#pragma warning disable

    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    internal sealed class DoesNotSupportPrefabModificationsAttribute : Attribute
    {
    }
}
#endif