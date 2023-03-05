namespace TalentManagementAPI.Application.Interfaces
{


    /// <summary>
    /// Interface for providing helper methods for models.
    /// </summary>
    /// <returns>
    /// GetModelFields() - Returns a string of model fields.
    /// ValidateModelFields(string fields) - Validates the given model fields and returns a string.
    /// </returns>
    public interface IModelHelper
    {
        string GetModelFields<T>();

        string ValidateModelFields<T>(string fields);
    }
}