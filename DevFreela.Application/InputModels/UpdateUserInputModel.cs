namespace DevFreela.Application.InputModels;

public class UpdateUserInputModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string BirthDate { get; set; }

    public UpdateUserInputModel(string fullName, string email, string birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
    }
}