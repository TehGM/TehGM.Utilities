namespace System.ComponentModel.DataAnnotations
{
    /// <summary>Validates that input of any type is a valid GUID.</summary>
    public class GuidAttribute : DataTypeAttribute
    {
        /// <summary>Marks member as GUID for validation purposes.</summary>
        public GuidAttribute() : base("GUID")
        {
            this.ErrorMessage = "Input is not a valid GUID/UUID format.";
        }

        /// <inheritdoc/>
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            return Guid.TryParse(value?.ToString(), out _);
        }
    }
}
