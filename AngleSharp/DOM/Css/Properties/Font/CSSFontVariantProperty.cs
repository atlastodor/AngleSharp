﻿namespace AngleSharp.DOM.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Information:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/font-variant
    /// </summary>
    sealed class CSSFontVariantProperty : CSSProperty, ICssFontVariantProperty
    {
        #region Fields

        internal static readonly FontVariant Default = FontVariant.Normal;
        internal static readonly IValueConverter<FontVariant> Converter = Toggle(Keywords.Normal, Keywords.SmallCaps).To(m => m ? FontVariant.Normal : FontVariant.SmallCaps);
        FontVariant _variant;

        #endregion

        #region ctor

        internal CSSFontVariantProperty(CSSStyleDeclaration rule)
            : base(PropertyNames.FontVariant, rule, PropertyFlags.Inherited)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected font variant transformation, if any.
        /// </summary>
        public FontVariant Variant
        {
            get { return _variant; }
        }

        #endregion

        #region Methods

        public void SetVariant(FontVariant variant)
        {
            _variant = variant;
        }

        internal override void Reset()
        {
            _variant = Default;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            return Converter.TryConvert(value, SetVariant);
        }

        #endregion
    }
}
