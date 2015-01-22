﻿using Sharpknife.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a collection editor that can edit any subtypes of the specified type.
	/// This class is mostly useful for allowing abstract classes to be edited by allowing their subtypes to be chosen.
	/// </summary>
	public class TypeCollectionEditor : CollectionEditor
	{
		/// <summary>
		/// Creates a new type collection editor.
		/// </summary>
		/// <param name="type"></param>
		public TypeCollectionEditor(Type type) : base(type)
		{
			this.Type = type.GetGenericArguments()[0];
		}

		/// <summary>
		/// Creates the new item types.
		/// </summary>
		/// <returns>the types</returns>
		protected override Type[] CreateNewItemTypes()
		{
			//find
			var types = Assemblies.GetSubTypesOf(this.Type);
			var array = types.ToArray();

			return array;
		}

		/// <summary>
		/// The type for the collection editor.
		/// </summary>
		public Type Type
		{
			get;
			private set;
		}
	}
}
