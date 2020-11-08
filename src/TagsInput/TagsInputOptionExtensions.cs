namespace Microsoft.AspNetCore.Mvc
{
    public static class TagsInputOptionExtensions
    {
        /// <summary>
        /// Classname for the tags, or a function returning a classname
        /// </summary>
        public static TOption TagClass<TOption>(this TOption option, string tagClass, bool isString = true) where TOption : TagsInputOption
        {
            option.Attributes["tagClass"] = isString ? string.Format("'{0}'", tagClass) : tagClass;
            return option;
        }

        /// <summary>
        /// When adding objects as tags, itemValue must be set to the name of the property containing the item's value, or a function returning an item's value.
        /// </summary>
        public static TOption ItemValue<TOption>(this TOption option, string itemValue, bool isString = true) where TOption : TagsInputOption
        {
            option.Attributes["itemValue"] = isString ? string.Format("'{0}'", itemValue) : itemValue;
            return option;
        }

        /// <summary>
        /// When adding objects as tags, you can set itemText to the name of the property of item to use for a its tag's text.
        /// You may also provide a function which returns an item's value. When this options is not set, the value of itemValue will be used
        /// </summary>
        public static TOption ItemText<TOption>(this TOption option, string itemText, bool isString = true) where TOption : TagsInputOption
        {
            option.Attributes["itemText"] = isString ? string.Format("'{0}'", itemText) : itemText;
            return option;
        }

        /// <summary>
        /// Array of keycodes which will add a tag when typing in the input. (default: [13, 188], which are ENTER and comma)
        /// </summary>
        public static TOption ConfirmKeys<TOption>(this TOption option, int[] keyCodes) where TOption : TagsInputOption
        {
            option.Attributes["confirmKeys"] = string.Format("[{0}]", string.Join(", ", keyCodes));
            return option;
        }

        /// <summary>
        /// When set, no more than the given number of tags are allowed to add (default: undefined).
        /// When maxTags is reached, a class 'bootstrap-tagsinput-max' is placed on the tagsinput element.
        /// </summary>
        public static TOption MaxTags<TOption>(this TOption option, int count) where TOption : TagsInputOption
        {
            if (count <= 0 || count == int.MaxValue)
                option.Attributes.Remove("maxTags");
            else
                option.Attributes["maxTags"] = count;
            return option;
        }

        /// <summary>
        /// Defines the maximum length of a single tag. (default: undefined)
        /// </summary>
        public static TOption MaxChars<TOption>(this TOption option, int count) where TOption : TagsInputOption
        {
            if (count <= 0 || count == int.MaxValue)
                option.Attributes.Remove("maxChars");
            else
                option.Attributes["maxChars"] = count;
            return option;
        }

        /// <summary>
        /// When true, automatically removes all whitespace around tags. (default: false)
        /// </summary>
        public static TOption TrimValue<TOption>(this TOption option, bool trimValue) where TOption : TagsInputOption
        {
            if (trimValue == false)
                option.Attributes.Remove("trimValue");
            else
                option.Attributes["trimValue"] = trimValue.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// When true, the same tag can be added multiple times. (default: false)
        /// </summary>
        public static TOption AllowDuplicates<TOption>(this TOption option, bool allowDuplicates) where TOption : TagsInputOption
        {
            if (allowDuplicates == false)
                option.Attributes.Remove("allowDuplicates");
            else
                option.Attributes["allowDuplicates"] = allowDuplicates.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// When the input container has focus, the class specified by this config option will be applied to the container
        /// </summary>
        public static TOption FocusClass<TOption>(this TOption option, string focusClass) where TOption : TagsInputOption
        {
            option.Attributes["focusClass"] = string.Format("'{0}'", focusClass);
            return option;
        }

        /// <summary>
        /// Allow creating tags which are not returned by typeahead's source (default: true)
        /// This is only possible when using string as tags.When itemValue option is set, this option will be ignored.
        /// </summary>
        public static TOption FreeInput<TOption>(this TOption option, bool freeInput) where TOption : TagsInputOption
        {
            if (freeInput == true)
                option.Attributes.Remove("freeInput");
            else
                option.Attributes["freeInput"] = freeInput.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// Boolean value controlling whether form submissions get processed when pressing enter in a field converted to a tagsinput (default: false).
        /// </summary>
        public static TOption CancelConfirmKeysOnEmpty<TOption>(this TOption option, bool cancelConfirmKeysOnEmpty) where TOption : TagsInputOption
        {
            if (cancelConfirmKeysOnEmpty == false)
                option.Attributes.Remove("cancelConfirmKeysOnEmpty");
            else
                option.Attributes["cancelConfirmKeysOnEmpty"] = cancelConfirmKeysOnEmpty.ToString().ToLower();
            return option;
        }

        /// <summary>
        /// Function invoked when trying to add an item which allready exists. By default, the existing tag hides and fades in.
        /// </summary>
        public static TOption OnTagExists<TOption>(this TOption option, string onTagExists) where TOption : TagsInputOption
        {
            option.Attributes["onTagExists"] = onTagExists;
            return option;
        }

        /// <summary>
        /// Url of a array items in json format
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static TOption AutoCompleteUrl<TOption>(this TOption option, string url) where TOption : TagsInputOption
        {
            option.AutoCompleteUrl = url;
            return option;
        }

        #region Typeahead
        ///// <summary>
        ///// An array for source of typeahead
        ///// </summary>
        //public static TOption Typeahead<TOption>(this TOption option, IEnumerable<string> items) where TOption : TagsInputOption
        //{
        //    option.Attributes["typeahead"] = "{ source: [" + string.Join(", ", items.Select(p => $"'{p}'")) + "] }";
        //    return option;
        //}

        ///// <summary>
        ///// Url of source for typeahead
        ///// </summary>
        //public static TOption Typeahead<TOption>(this TOption option, string url, string arg = "query") where TOption : TagsInputOption
        //{
        //    option.Attributes["typeahead"] = "{ source: function(query) { return $.get('" + url + "', new { " + arg + ": query }); } }";
        //    return option;
        //}

        ///// <summary>
        ///// function returning a promise or array for source of typeahead
        ///// </summary>
        //public static TOption TypeaheadFunc<TOption>(this TOption option, string function) where TOption : TagsInputOption
        //{
        //    option.Attributes["typeahead"] = "{ source: " + function + " }";
        //    return option;
        //}
        #endregion

        //Methods and Events
        //https://bootstrap-tagsinput.github.io/bootstrap-tagsinput/examples/#methods
    }
}
