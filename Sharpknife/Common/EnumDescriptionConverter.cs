using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents an enumartion converter that displays enums by a <see cref="System.ComponentModel.DescriptionAttribute" /> if available.
	/// </summary>
	public class EnumDescriptionConverter : EnumConverter
	{
		/// <summary>
		/// Creates a new enum description converter.
		/// </summary>
		/// <param name="type">the type</param>
		public EnumDescriptionConverter(Type type) : base(type)
		{
			this.Type = type;
		}

		/// <summary>
		/// Returns if the specified type can be converted to.
		/// </summary>
		/// <param name="context">the context</param>
		/// <param name="destinationType">the destination type</param>
		/// <returns>if the type can be converted to</returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return (destinationType == typeof(string));
		}

		/// <summary>
		/// Returns if the specified type can be converted from.
		/// </summary>
		/// <param name="context">the context</param>
		/// <param name="sourceType">the source type</param>
		/// <returns>if the type can be converted from</returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return (sourceType == typeof(string));
		}

		/// <summary>
		/// Converts the specified type into a string.
		/// </summary>
		/// <param name="context">the context</param>
		/// <param name="culture">the culture</param>
		/// <param name="value">the value</param>
		/// <param name="destinationType">the destination type</param>
		/// <returns>the result</returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			//description
			var fieldInfo = this.Type.GetField(Enum.GetName(this.Type, value));
			var descriptionAttribute = (DescriptionAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

			if (descriptionAttribute != null)
			{
				return descriptionAttribute.Description;
			}
			else
			{
				return value.ToString();
			}
		}

		/// <summary>
		/// Converts the specified type from a string.
		/// </summary>
		/// <param name="context">the context</param>
		/// <param name="culture">the culture</param>
		/// <param name="value">the value</param>
		/// <returns>the result</returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			foreach (var fieldInfo in this.Type.GetFields())
			{
				//description attribute
				var descriptionAttribute = (DescriptionAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

				if (descriptionAttribute != null)
				{
					//description
					var description = descriptionAttribute.Description;

					if (description == (string) value)
					{
						return Enum.Parse(this.Type, fieldInfo.Name);
					}
				}
			}

			return Enum.Parse(this.Type, (string) value);
		}

		/// <summary>
		/// The type for the enum converter.
		/// </summary>
		public Type Type
		{
			get;
			private set;
		}
	}
}
